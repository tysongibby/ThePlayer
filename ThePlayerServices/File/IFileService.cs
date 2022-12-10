using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThePlayerServices.File
{
    internal interface IFileService
    {        
        void ProcessArguments(string[] iArgs);

        Task<IList<TrackViewModel>> ProcessFilesInDirectoryAsync(string directoryPath);

        Task<IList<TrackViewModel>> ProcessFilesAsync(IList<string> filenames, bool processPlaylistFiles);

        Task<TrackViewModel> CreateTrackAsync(string path);

        event TracksImportedHandler TracksImported;
        event EventHandler ImportingTracks;
    }
}
