using ThePlayer.Shared.Models.Views;
using System.Collections.Generic;

namespace ThePlayer.Shared.Services.Playback
{
    public class EnqueueResult
    {
        public bool IsSuccess { get; set; }

        public IList<TrackViewModel> EnqueuedTracks { get; set; }
    }
}
