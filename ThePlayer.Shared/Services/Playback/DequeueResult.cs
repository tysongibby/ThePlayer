using ThePlayer.Shared.Models.Views;
using System.Collections.Generic;

namespace ThePlayer.Shared.Services.Playback
{
    public class DequeueResult
    {
        public bool IsSuccess { get; set; }

        public IList<TrackViewModel> DequeuedTracks { get; set; }

        public bool IsPlayingTrackDequeued { get; set; }

        public TrackViewModel NextAvailableTrack { get; set; }
    }
}
