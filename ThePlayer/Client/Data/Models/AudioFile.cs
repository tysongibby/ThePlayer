﻿using System;
using System.Collections.Generic;

namespace ThePlayer.Client.Data.Models
{
    public class AudioFile
    {
        public long Id { get; set; }

        public List<string> Artists { get; set; }

        public List<string> Genres { get; set; }

        public string AlbumTitle { get; set; }

        public List<string> AlbumArtists { get; set; }

        public string AlbumKey { get; set; }

        public string Path { get; set; }

        public string SafePath { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }

        public long? FileSize { get; set; }

        public long? BitRate { get; set; }

        public long? SampleRate { get; set; }

        public string TrackTitle { get; set; }

        public long? TrackNumber { get; set; }

        public long? TrackCount { get; set; }

        public long? DiscNumber { get; set; }

        public long? DiscCount { get; set; }

        public long? Duration { get; set; }

        public long? Year { get; set; }

        public long? HasLyrics { get; set; }

        public long DateAdded { get; set; }

        public long DateFileCreated { get; set; }

        public long DateLastSynced { get; set; }

        public long DateFileModified { get; set; }

        public long? NeedsIndexing { get; set; }

        public long? NeedsAlbumArtworkIndexing { get; set; }

        public long? IndexingSuccess { get; set; }

        public string IndexingFailureReason { get; set; }

        public long? Rating { get; set; }

        public long? Love { get; set; }

        public long? PlayCount { get; set; }

        public long? SkipCount { get; set; }

        public long? DateLastPlayed { get; set; }

        //public static AudioFile CreateDefault(string path)
        //{
        //    var audioFile = new AudioFile()
        //    {
        //        Path = path,
        //        SafePath = path.ToSafePath(),
        //        FileName = System.IO.Path.GetFileNameWithoutExtension(path),
        //        IndexingSuccess = 0,
        //        DateAdded = DateTime.Now.Ticks
        //    };

        //    return audioFile;
        //}


        //public AudioFile ShallowCopy()
        //{
        //    return (AudioFile)this.MemberwiseClone();
        //}


        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.SafePath.Equals(((AudioFile)obj).SafePath);
        }

        public override int GetHashCode()
        {
            return new { this.SafePath }.GetHashCode();
        }
    }
}
