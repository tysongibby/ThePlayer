using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Data.Models
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [ForeignKey("Artists")]
        public int ArtistId { get; set; }
        
        [ForeignKey("SongGenres")]
        public int GenreId { get; set; }
        
        [ForeignKey("Albums")]
        public int AlbumId { get; set; }

        [Required]
        [ForeignKey("AudioFiles")]
        public int AudioFileId { get; set; }

        public string MimeType { get; set; }

        public long? FileSize { get; set; }

        public long? BitRate { get; set; }

        public long? SampleRate { get; set; }       

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

        //public static Song CreateDefault(string path)
        //{
        //    var song = new Song()
        //    {
        //        Path = path,
        //        SafePath = path.ToSafePath(),
        //        FileName = System.IO.Path.GetFileNameWithoutExtension(path),
        //        IndexingSuccess = 0,
        //        DateAdded = DateTime.Now.Ticks
        //    };

        //    return song;
        //}


        //public Song ShallowCopy()
        //{
        //    return (Song)this.MemberwiseClone();
        //}


        public override bool Equals(object obj)
        {
            //if (obj == null || !GetType().Equals(obj.GetType()))
            //{
            //    return false;
            //}

            //return this.SafePath.Equals(((AudioFile)obj).SafePath);
            throw new NotImplementedException("Song.Equals() is not yet implemented");
        }

        public override int GetHashCode()
        {
            //return new { this.SafePath }.GetHashCode();
            throw new NotImplementedException("Song.GetHashCode() is not yet implemented");
        }
    }

}

