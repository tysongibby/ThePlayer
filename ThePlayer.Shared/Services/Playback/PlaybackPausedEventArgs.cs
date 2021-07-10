using System;

namespace ThePlayer.Shared.Services.Playback
{
    public class PlaybackPausedEventArgs : EventArgs
    {
        public bool IsSilent { get; set; }
    }
}