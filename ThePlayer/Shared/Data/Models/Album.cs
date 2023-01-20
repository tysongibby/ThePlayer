using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Data.Models
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Genres")]        
        public int GenreId { get; set; }

        [ForeignKey("Artists")]
        public int ArtistId { get; set; }

        //public string AlbumKey { get; set; }
    }
}
