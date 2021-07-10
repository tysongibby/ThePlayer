using System;

namespace ThePlayer.Shared.Services.Audio
{
    public class PlaybackInterruptedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
