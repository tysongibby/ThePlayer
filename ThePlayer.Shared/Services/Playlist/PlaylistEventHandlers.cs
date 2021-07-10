using ThePlayer.Shared.Models.Views;

namespace ThePlayer.Shared.Services.Playlist
{
    public delegate void TracksAddedHandler(int numberTracksAdded, string playlistName);
    public delegate void TracksDeletedHandler(PlaylistViewModel playlist);
}
