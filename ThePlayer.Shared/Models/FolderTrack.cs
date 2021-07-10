using System.ComponentModel.DataAnnotations;
//using System.Data.SQLite;
//using SQLite;
// TODO: update SQLite to System.Data.SQLite ?

namespace ThePlayer.Shared.Models
{
    public class FolderTrack
    {
        //[PrimaryKey(), AutoIncrement()]
        [Key]
        public long FolderTrackID { get; set; }

        public long FolderID { get; set; }

        public long TrackID { get; set; }

        public FolderTrack()
        {
        }

        public FolderTrack(long folderId, long trackId)
        {
            this.FolderID = folderId;
            this.TrackID = trackId;
        }
    }
}
