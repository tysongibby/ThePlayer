using System.Threading.Tasks;

namespace ThePlayer.Shared.Services.Lyrics.Apis
{
    public interface ILyricsApi
    {
        string SourceName { get; }
        Task<string> GetLyricsAsync(string artist, string title);
    }
}