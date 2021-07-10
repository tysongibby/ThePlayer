using System;
using System.Collections.Generic;

namespace ThePlayer.Shared.Services.Indexing
{
    public class AlbumArtworkAddedEventArgs : EventArgs
    {
        public IList<string> AlbumKeys { get; set; }
    }
}