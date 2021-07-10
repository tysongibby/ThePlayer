using ThePlayer.Shared.Models;
using ThePlayer.Shared.Utilities;
using Prism.Mvvm;
using System;



namespace ThePlayer.Shared.Models.Views
{
    public class ArtistViewModel : BindableBase 
    {
        private string artistName;
        private bool isHeader;

        public ArtistViewModel(string artistName)
        {
            this.artistName = DataUtils.TrimColumnValue(artistName);
            this.isHeader = false;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                SetProperty<string>(ref this.artistName, value);
            }
        }

        public string SortArtistName => FormatUtils.GetSortableString(this.artistName, true);

        //TODO: SemanticZoomUtils seems to be Windows UI specific and so is likely not needed
        //public string Header => SemanticZoomUtils.GetGroupHeader(this.artistName, true);

        public bool IsHeader
        {
            get { return this.isHeader; }
            set { SetProperty<bool>(ref this.isHeader, value); }
        }

        public override string ToString()
        {
            return this.artistName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return string.Equals(this.artistName, ((ArtistViewModel)obj).artistName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.artistName.GetHashCode();
        }
    }
}
