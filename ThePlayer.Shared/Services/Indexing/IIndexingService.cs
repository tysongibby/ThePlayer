﻿using System;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Services.Indexing
{
    public delegate void AlbumArtworkAddedEventHandler(object sender, AlbumArtworkAddedEventArgs e);

    public interface IIndexingService
    {
        void OnFoldersChanged();

        bool IsIndexing { get; }

        Task RefreshCollectionAsync();

        void RefreshCollectionIfFoldersChangedAsync();

        Task RefreshCollectionImmediatelyAsync();

        void ReScanAlbumArtworkAsync(bool reloadOnlyMissing);

        event EventHandler IndexingStarted;

        event EventHandler IndexingStopped;

        event Action<IndexingStatusEventArgs> IndexingStatusChanged;

        event EventHandler RefreshLists;

        event AlbumArtworkAddedEventHandler AlbumArtworkAdded;
    }
}
