using ThePlayer.Shared.Io;
//using Prism.Mvvm;

namespace ThePlayer.Shared.Models.Views
{
    public class SmartPlaylistLimitViewModel
    {
        private SmartPlaylistLimitType type;
        private int value;
        private bool isEnabled;

        public SmartPlaylistLimitViewModel(SmartPlaylistLimitType type, int value)
        {
            this.type = type;
            this.value = value;
        }

        public SmartPlaylistLimitType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.isEnabled = value; }
        }

        public SmartPlaylistLimit ToSmartPlaylistLimit()
        {
            return new SmartPlaylistLimit(this.type, this.isEnabled ? this.value : 0);
        }
    }
}
