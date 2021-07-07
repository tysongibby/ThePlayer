using System.ComponentModel.DataAnnotations;
//using SQLite;

namespace ThePlayer.Shared.Models
{
    public class Folder
    {
        //[PrimaryKey(), AutoIncrement()]
        [Key]
        public long FolderID { get; set; }

        public string Path { get; set; }

        public string SafePath { get; set; }

        public long ShowInCollection { get; set; }
    }
}
