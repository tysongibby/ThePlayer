using System;

namespace ThePlayer.Shared.Services.Playback
{
    public class PlaybackFailedEventArgs : EventArgs
    {
        public PlaybackFailureReason FailureReason { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
