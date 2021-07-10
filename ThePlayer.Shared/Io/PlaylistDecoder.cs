﻿using ThePlayer.Shared.Utilities;
using ThePlayer.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ThePlayer.Shared.Io
{
    public class PlaylistEntry
    {
        public PlaylistEntry(string referencePath, string decodedPath)
        {
            this.ReferencePath = referencePath;
            this.DecodedPath = decodedPath;
        }

        public string ReferencePath { get; private set; }
        public string DecodedPath { get; private set; }
    }
    public class DecodePlaylistResult
    {
        public DecodePlaylistResult(OperationResult decodeResult, string playlistName, IList<PlaylistEntry> playlistEntries)
        {
            this.DecodeResult = decodeResult;
            this.PlaylistName = playlistName;
            this.PlaylistEntries = playlistEntries;
        }

        public OperationResult DecodeResult { get; }

        public string PlaylistName { get; }

        public IList<PlaylistEntry> PlaylistEntries { get; }

        public IList<string> Paths => this.PlaylistEntries != null && this.PlaylistEntries.Count > 0 ? this.PlaylistEntries.Select(x => x.DecodedPath).ToList() : new List<string>();
    }

    public class PlaylistDecoder
    {
        public DecodePlaylistResult DecodePlaylist(string fileName)
        {
            OperationResult decodeResult = new OperationResult { Result = false };

            string playlistName = string.Empty;
            IList<PlaylistEntry> playlistEntries = new List<PlaylistEntry>();

            if (System.IO.Path.GetExtension(fileName.ToLower()) == FileFormats.M3U | System.IO.Path.GetExtension(fileName.ToLower()) == FileFormats.M3U8)
            {
                decodeResult = this.DecodeM3uPlaylist(fileName, ref playlistName, ref playlistEntries);
            }
            else if (System.IO.Path.GetExtension(fileName.ToLower()) == FileFormats.WPL | System.IO.Path.GetExtension(fileName.ToLower()) == FileFormats.ZPL)
            {
                decodeResult = this.DecodeZplPlaylist(fileName, ref playlistName, ref playlistEntries);
            }

            return new DecodePlaylistResult(decodeResult, playlistName, playlistEntries);
        }

        private string GenerateFullTrackPath(string playlistPath, string trackPath)
        {
            var fullPath = string.Empty;
            string playlistDirectory = System.IO.Path.GetDirectoryName(playlistPath);

            if (FileUtils.IsAbsolutePath(trackPath))
            {
                // The line contains the full path.
                fullPath = trackPath;
            }
            else
            {
                // The line contains a relative path, let's construct the full path by ourselves.
                string tempFullPath = string.Empty;

                if (trackPath.StartsWith(@"\\"))
                {
                    // This is a network path. Just return as is.
                    return trackPath;
                }

                if (trackPath.StartsWith(@"\"))
                {
                    // Path starts with "\": add preceeding "." to make it a valid relative path.
                    trackPath = "." + trackPath;
                }

                tempFullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(playlistDirectory, trackPath));

                if (!string.IsNullOrEmpty(tempFullPath) && FileUtils.IsAbsolutePath(tempFullPath))
                {
                    fullPath = tempFullPath;
                }
            }

            return fullPath;
        }

        private OperationResult DecodeM3uPlaylist(string playlistPath, ref string playlistName, ref IList<PlaylistEntry> playlistEntries)
        {
            var op = new OperationResult();

            try
            {
                playlistName = System.IO.Path.GetFileNameWithoutExtension(playlistPath);

                using (System.IO.StreamReader sr = System.IO.File.OpenText("" + playlistPath + ""))
                {
                    string line = sr.ReadLine();

                    while (!(line == null))
                    {
                        // We don't process empty lines and lines containing comments
                        if (!string.IsNullOrEmpty(line) && !line.StartsWith("#"))
                        {
                            string fullTrackPath = this.GenerateFullTrackPath(playlistPath, line);

                            if (!string.IsNullOrEmpty(fullTrackPath))
                            {
                                playlistEntries.Add(new PlaylistEntry(line, fullTrackPath));
                            }
                        }

                        line = sr.ReadLine();
                    }
                }

                op.Result = true;
            }
            catch (Exception ex)
            {
                op.AddMessage(ex.Message);
                op.Result = false;
            }

            return op;
        }

        private OperationResult DecodeZplPlaylist(string playlistPath, ref string playlistName, ref IList<PlaylistEntry> playlistEntries)
        {
            OperationResult op = new OperationResult();

            try
            {
                playlistName = System.IO.Path.GetFileNameWithoutExtension(playlistPath);

                XDocument zplDocument = XDocument.Load(playlistPath);

                // Get the title of the playlist
                var titleElement = (from t in zplDocument.Element("smil").Element("head").Elements("title")
                                    select t).FirstOrDefault();

                if (titleElement != null)
                {
                    // If assigning the title which is fetched from the <title/> element fails,
                    // the filename is used as playlist title.
                    try
                    {
                        playlistName = titleElement.Value;

                    }
                    catch (Exception)
                    {
                        // Swallow
                    }
                }

                // Get the songs
                var mediaElements = from t in zplDocument.Element("smil").Element("body").Element("seq").Elements("media")
                                    select t;

                if (mediaElements != null && mediaElements.Count() > 0)
                {
                    foreach (XElement mediaElement in mediaElements)
                    {
                        string fullTrackPath = this.GenerateFullTrackPath(playlistPath, mediaElement.Attribute("src").Value);

                        if (!string.IsNullOrEmpty(fullTrackPath))
                        {
                            playlistEntries.Add(new PlaylistEntry(mediaElement.Attribute("src").Value, fullTrackPath));
                        }
                    }
                }

                op.Result = true;
            }
            catch (Exception ex)
            {
                op.AddMessage(ex.Message);
                op.Result = false;
            }

            return op;
        }
    }
}
