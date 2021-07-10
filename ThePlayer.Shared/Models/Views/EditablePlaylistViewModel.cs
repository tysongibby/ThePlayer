using ThePlayer.Shared.Utilities;
using ThePlayer.Shared.Services.Playlist;
using System.Collections.ObjectModel;
using System.Linq;

namespace ThePlayer.Shared.Models.Views
{
    public class EditablePlaylistViewModel
    {
        private string playlistName;
        private PlaylistType type;
        private bool matchAnyRule;
        private SmartPlaylistLimitViewModel limit;
        private ObservableCollection<SmartPlaylistTypeViewModel> limitTypes = new ObservableCollection<SmartPlaylistTypeViewModel>();
        private SmartPlaylistTypeViewModel selectedLimitType;
        private ObservableCollection<SmartPlaylistRuleViewModel> rules = new ObservableCollection<SmartPlaylistRuleViewModel>();
        private string path;

        public EditablePlaylistViewModel(string playlistName, PlaylistType type)
        {
            this.playlistName = playlistName;
            this.type = type;
            this.rules.Add(new SmartPlaylistRuleViewModel());
            this.limit = new SmartPlaylistLimitViewModel(SmartPlaylistLimitType.Songs, 25);

            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.Songs, ResourceUtils.GetString("Language_Smart_Playlist_Songs")));
            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.GigaBytes, ResourceUtils.GetString("Language_Gigabytes_Short")));
            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.MegaBytes, ResourceUtils.GetString("Language_Megabytes_Short")));
            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.Minutes, ResourceUtils.GetString("Language_Smart_Playlist_Minutes")));
            this.selectedLimitType = this.limitTypes.First();
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public string PlaylistName
        {
            get { return this.playlistName; }
            set { this.playlistName = value; }
        }

        public PlaylistType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public bool MatchAnyRule
        {
            get { return this.matchAnyRule; }
            set { this.matchAnyRule = value; }
        }

        public SmartPlaylistLimitViewModel Limit
        {
            get { return this.limit; }
            set { this.limit = value; }
        }

        public ObservableCollection<SmartPlaylistTypeViewModel> LimitTypes
        {
            get { return this.limitTypes; }
            set { this.limitTypes = value; }
        }

        public ObservableCollection<SmartPlaylistRuleViewModel> Rules
        {
            get { return this.rules; }
            set { this.rules = value; }
        }

        public SmartPlaylistTypeViewModel SelectedLimitType
        {
            get { return this.selectedLimitType; }
            set {
                this.selectedLimitType = value;
                
                if(this.limit != null)
                {
                    this.limit.Type = value.Type;
                }
            }
        }

        public void AddRule()
        {
            this.rules.Add(new SmartPlaylistRuleViewModel());
        }

        public void RemoveRule(SmartPlaylistRuleViewModel rule)
        {
            // There must be at least 1 rule
            if (this.rules.Count > 1)
            {
                this.rules.Remove(rule);
            }
        }
    }
}
