﻿namespace ThePlayer.Share.Io
{
    public class FolderPathInfo
    {
        public long FolderId { get; }
        public string Path { get; }
        public long DateModifiedTicks { get; }

        public FolderPathInfo(long folderId, string path, long dateModifiedTicks)
        {
            this.FolderId = folderId;
            this.Path = path;
            this.DateModifiedTicks = dateModifiedTicks;
        }
    }
}
