namespace ThePlayer.Shared.Models
{
    public class PlaybackCounter
    {
        public string Path { get; set; }

        public long PlayCount { get; set; }

        public long SkipCount { get; set; }

        public long DateLastPlayed { get; set; }

        public string SafePath { get; set; }
    }
}
