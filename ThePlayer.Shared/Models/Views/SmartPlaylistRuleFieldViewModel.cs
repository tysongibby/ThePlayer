namespace ThePlayer.Shared.Models.Views
{
    public enum SmartPlaylistRuleFieldDataType
    {
        Text = 0,
        Numeric = 1,
        Boolean = 2
    }

    public class SmartPlaylistRuleFieldViewModel
    {
        private string displayName;
        private string name;
        private SmartPlaylistRuleFieldDataType dataType;

        public SmartPlaylistRuleFieldViewModel(string displayName, string name, SmartPlaylistRuleFieldDataType dataType)
        {
            this.displayName = displayName;
            this.name = name;
            this.dataType = dataType;
        }

        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public SmartPlaylistRuleFieldDataType DataType
        {
            get { return this.dataType; }
            set { this.dataType = value; }
        }

        public override string ToString()
        {
            return this.displayName;
        }
    }
}