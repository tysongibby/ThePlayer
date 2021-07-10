using ThePlayer.Shared.Models.Views;
using ThePlayer.Shared.Models;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Extensions
{
    public static class ContainerProviderExtensions
    {
        // TODO: replace Prisom.Ioc.IContainerProvider with?
        public static TrackViewModel ResolveTrackViewModel(this IContainerProvider container, Track track)
        {
            var getTrackViewModel = container.Resolve<Func<Track, TrackViewModel>>();
            return getTrackViewModel(track);
        }

        // TODO: replace Prisom.Ioc.IContainerProvider with?
        public async static Task<IList<TrackViewModel>> ResolveTrackViewModelsAsync(this IContainerProvider container, IList<Track> tracks)
        {
            IList<TrackViewModel> trackViewModels = null;
            await Task.Run(() => { trackViewModels = tracks.Select(t => container.ResolveTrackViewModel(t)).ToList(); });

            return trackViewModels;
        }
    }
}
