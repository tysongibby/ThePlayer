using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ThePlayer.Shared.Data.Models
{
    [Table("AudioFiles")]
    public class AudioFile
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Path { get; set; }
        //public string SafePath { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.Path.Equals(((AudioFile)obj).Path);
        }

        public override int GetHashCode()
        {
            //return new { this.SafePath }.GetHashCode();
            throw new NotImplementedException("AudioFile.GetHashCode() is not yet implemented");
        }
    }
}
