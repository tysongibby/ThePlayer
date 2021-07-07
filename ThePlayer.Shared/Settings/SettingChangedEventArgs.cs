using System;

namespace ThePlayer.Shared.Settings
{
    public class SettingChangedEventArgs : EventArgs
    {
        public SettingEntry Entry { get; set; }
    }
}
