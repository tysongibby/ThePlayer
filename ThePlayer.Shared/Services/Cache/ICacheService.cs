﻿using System;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Services.Cache
{
    public interface ICacheService
    {
        string CoverArtCacheFolderPath { get; }

        string TemporaryCacheFolderPath { get; }

        Task<string> CacheArtworkAsync(byte[] artwork);

        Task<string> CacheArtworkAsync(string uriString);

        string GetCachedArtworkPath(string artworkID);

        Task<string> DownloadFileToTemporaryCacheAsync(string uriString);

    }
}
