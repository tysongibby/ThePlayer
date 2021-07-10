﻿using ThePlayer.Shared.Models.Views;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Services.File
{
    public delegate void TracksImportedHandler(IList<TrackViewModel> tracks, TrackViewModel trackToPlay);

    [ServiceContract(Namespace = "http://Dopamine.FileService")]
    public interface IFileService
    {
        [OperationContract()]
        void ProcessArguments(string[] iArgs);

        Task<IList<TrackViewModel>> ProcessFilesInDirectoryAsync(string directoryPath);

        Task<IList<TrackViewModel>> ProcessFilesAsync(IList<string> filenames, bool processPlaylistFiles);

        Task<TrackViewModel> CreateTrackAsync(string path);

        event TracksImportedHandler TracksImported;
        event EventHandler ImportingTracks;
    }
}
