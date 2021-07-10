﻿using ThePlayer.Shared.Services.Playlist;
using Prism.Mvvm;
using System;

namespace ThePlayer.Shared.Models.Views
{
    public class PlaylistViewModel : BindableBase
    {
        public string Name { get; }

        public string Path { get; }

        public PlaylistType Type { get; }

        public bool IsSmartPlaylist => this.Type.Equals(PlaylistType.Smart);

        public string SortName => Name.ToLowerInvariant();

        public PlaylistViewModel(string name, string path, PlaylistType type)
        {
            this.Name = name;
            this.Path = path;
            this.Type = type;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.Name.Equals(((PlaylistViewModel)obj).Name, StringComparison.OrdinalIgnoreCase) & this.Type.Equals(((PlaylistViewModel)obj).Type);
        }

        public override int GetHashCode()
        {
            return this.Path.GetHashCode();
        }
    }
}
