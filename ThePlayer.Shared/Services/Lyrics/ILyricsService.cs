using System.Collections.Generic;
using ThePlayer.Shared.Models.Views;

namespace ThePlayer.Shared.Services.Lyrics
{
    public interface ILyricsService
    {
        IList<LyricsLineViewModel> ParseLyrics(Apis.Lyrics lyrics);
    }
}
