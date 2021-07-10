using System.ComponentModel.DataAnnotations;
//TODO: update SQLite to System.Data.SQLite?
//using SQLite;

namespace ThePlayer.Shared.Models
{
    public class Configuration
    {
        //[PrimaryKey(), AutoIncrement()]
        [Key]
        public long ConfigurationID { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
