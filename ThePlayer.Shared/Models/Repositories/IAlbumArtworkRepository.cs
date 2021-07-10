﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Models.Repositories
{
    public interface IAlbumArtworkRepository
    {
        Task<IList<AlbumArtwork>> GetAlbumArtworkAsync();

        Task<AlbumArtwork> GetAlbumArtworkAsync(string albumKey);

        Task<AlbumArtwork> GetAlbumArtworkForPathAsync(string path);

        Task DeleteAlbumArtworkAsync(string albumKey);

        Task<long> DeleteUnusedAlbumArtworkAsync();

        Task<IList<string>> GetArtworkIdsAsync();

        Task UpdateAlbumArtworkAsync(string albumKey, string artworkId);
    }
}
