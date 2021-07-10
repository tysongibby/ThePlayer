using ThePlayer.Shared.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace ThePlayer.Shared.Models.Views
{
    public class AlbumViewModel
    {
        private string albumTitle;
        private string albumArtist;
        private IList<string> albumArtists;
        private string year;
        private string artworkPath;
        private string mainHeader;
        private string subHeader;
        private long? dateAdded;
        private long? dateFileCreated;
        private long sortYear;

        public AlbumViewModel(AlbumData albumData)
        {
            this.albumArtist = this.GetAlbumArtist(albumData);
            this.albumTitle = !string.IsNullOrEmpty(albumData.AlbumTitle) ? albumData.AlbumTitle : ResourceUtils.GetString("Language_Unknown_Album");
            this.albumArtists = this.GetAlbumArtists(albumData);
            this.year = albumData.Year.HasValue && albumData.Year.Value > 0 ? albumData.Year.Value.ToString() : string.Empty;
            this.SortYear = albumData.Year.HasValue ? albumData.Year.Value : 0;
            this.AlbumKey = albumData.AlbumKey;
            this.DateAdded = albumData.DateAdded;
            this.DateFileCreated = albumData.DateFileCreated;
        }

        private string GetAlbumArtist(AlbumData albumData)
        {
            if (!string.IsNullOrEmpty(albumData.AlbumTitle))
            {
                if (!string.IsNullOrEmpty(albumData.AlbumArtists))
                {
                    return DataUtils.GetCommaSeparatedColumnMultiValue(albumData.AlbumArtists);
                }
                else if (!string.IsNullOrEmpty(albumData.Artists))
                {
                    return DataUtils.GetCommaSeparatedColumnMultiValue(albumData.Artists);
                }
            }

            return ResourceUtils.GetString("Language_Unknown_Artist");
        }

        public List<string> GetAlbumArtists(AlbumData albumData)
        {
            if (!string.IsNullOrEmpty(albumData.AlbumArtists))
            {
                return DataUtils.SplitAndTrimColumnMultiValue(albumData.AlbumArtists).ToList();
            }
            else if (!string.IsNullOrEmpty(albumData.Artists))
            {
                return DataUtils.SplitAndTrimColumnMultiValue(albumData.Artists).ToList();
            }

            return new List<string>();
        }

        public string AlbumKey { get; set; }

        public long? DateAdded
        {
            get { return this.dateAdded; }
            set
            {
                this.dateAdded = value;
            }
        }

        public long? DateFileCreated
        {
            get { return this.dateFileCreated; }
            set
            {
                this.dateFileCreated = value;
            }
        }

        public double Opacity { get; set; }

        public bool HasCover
        {
            get { return !string.IsNullOrEmpty(this.artworkPath); }
        }

        public bool HasTitle
        {
            get { return !string.IsNullOrEmpty(this.AlbumTitle); }
        }

        public string ToolTipYear
        {
            get { return !string.IsNullOrEmpty(this.year) ? "(" + this.year + ")" : string.Empty; }
        }

        public string Year
        {
            get { return this.year; }
            set
            {
                this.year = value;
                //TODO: AlbumViewModel.cs line 108 Prism MVVM property changed fix
                //RaisePropertyChanged(nameof(this.ToolTipYear));
            }
        }

        public long SortYear
        {
            get { return this.sortYear; }
            set
            {
                this.sortYear = value;
            }
        }

        public string AlbumTitle
        {
            get { return this.albumTitle; }
            set
            {
                this.albumTitle = value;
                //TODO: AlbumViewModel.cs line 108 Prism MVVM property changed fix
                //RaisePropertyChanged(nameof(this.HasTitle));
            }
        }

        public string AlbumArtist
        {
            get { return this.albumArtist; }
            set { this.albumArtist = value; }
        }

        public IList<string> AlbumArtists
        {
            get { return this.albumArtists; }
            set { this.albumArtists = value; }
        }

        public string ArtworkPath
        {
            get { return this.artworkPath; }
            set
            {
                this.artworkPath = value;
                //TODO: AlbumViewModel.cs line 108 Prism MVVM property changed fix
                //RaisePropertyChanged(nameof(this.HasCover));
            }
        }

        public string MainHeader
        {
            get { return this.mainHeader; }
            set { this.mainHeader = value; }
        }

        public string SubHeader
        {
            get { return this.subHeader; }
            set { this.subHeader = value; }
        }

        public override string ToString()
        {
            return this.albumTitle;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.AlbumKey.Equals(((AlbumViewModel)obj).AlbumKey);
        }

        public override int GetHashCode()
        {
            return this.AlbumKey.GetHashCode();
        }
    }
}
