﻿using System.ComponentModel.DataAnnotations;
//using SQLite;

namespace ThePlayer.Shared.Models
{
    public class RemovedTrack
    {
        //[PrimaryKey(), AutoIncrement()]
        [Key]
        public long TrackID { get; set; }

        public string Path { get; set; }

        public string SafePath { get; set; }

        public long DateRemoved { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.SafePath.Equals(((RemovedTrack)obj).SafePath);
        }

        public override int GetHashCode()
        {
            return new { this.SafePath }.GetHashCode();
        }
    }
}
