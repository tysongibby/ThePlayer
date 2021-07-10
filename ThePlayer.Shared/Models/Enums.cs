namespace ThePlayer.Shared.Models
{
    public enum AddFolderResult
    {
        Error = 0,
        Success = 1,
        Duplicate = 2,
        Inaccessible = 3
    }

    public enum RemoveFolderResult
    {
        Error = 0,
        Success = 1
    }

    public enum ArtistType
    {
        All = 0,
        Track = 1,
        Album = 2
    }

    public enum TrackOrder
    {
        Alphabetical = 1,
        ByAlbum = 2,
        ByFileName = 3,
        ByRating = 4,
        ReverseAlphabetical = 5,
        None = 6
    }

    public enum AlbumOrder
    {
        Alphabetical = 1,
        ByDateAdded = 2,
        ByDateCreated = 3,
        ByAlbumArtist = 4,
        ByYearDescending = 5,
        ByYearAscending = 6
    }
    public enum RemoveTracksResult
    {
        Error = 0,
        Success = 1
    }

    public enum NotificationPosition
    {
        BottomLeft = 1,
        TopLeft = 2,
        TopRight = 3,
        BottomRight = 4
    }

    public enum LoopMode
    {
        None = 1,
        One = 2,
        All = 3
    }

    public enum CoverSizeType
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    public enum SpectrumChannel
    {
        Left = 1,
        Right = 2,
        Stereo = 3,
    }

    public enum SpectrumStyle
    {
        Flames = 1,
        Lines = 2,
        Bars = 3
    }

    public enum SmartPlaylistLimitType
    {
        Songs = 1,
        GigaBytes = 2,
        MegaBytes = 3,
        Minutes = 4
    }

}
