using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Models.Repositories
{
    public interface IQueuedTrackRepository
    {
        Task<List<QueuedTrack>> GetSavedQueuedTracksAsync();
        Task SaveQueuedTracksAsync(IList<QueuedTrack> tracks);
        Task<QueuedTrack> GetPlayingTrackAsync();
    }
}
