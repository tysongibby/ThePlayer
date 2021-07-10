using System;

namespace ThePlayer.Shared.Services.MetaDataService
{
    public class LoveChangedEventArgs : EventArgs
    {
        public string SafePath { get; }
        public bool Love { get; }

        public LoveChangedEventArgs(string safePath, bool love)
        {
            this.SafePath = safePath;
            this.Love = love;
        }
    }
}
