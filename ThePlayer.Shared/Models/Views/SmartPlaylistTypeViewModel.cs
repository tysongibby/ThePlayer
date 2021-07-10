namespace ThePlayer.Shared.Models.Views
{
    public class SmartPlaylistTypeViewModel
    {
        private SmartPlaylistLimitType type;
        private string displayName;

        public SmartPlaylistTypeViewModel(SmartPlaylistLimitType type, string displayName)
        {
            this.type = type;
            this.displayName = displayName;
        }

        public SmartPlaylistLimitType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        public override string ToString()
        {
            return this.DisplayName;
        }

    }
}
