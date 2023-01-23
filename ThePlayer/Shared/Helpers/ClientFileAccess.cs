using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Helpers
{
    // requires clientFileAccess.js
    public class ClientFileAccess : JSModuleBase
    {
        public ClientFileAccess(IJSRuntime js) : base(js, "/js/audioFileAccess.js")
        {
        }

        // CRUD operations
        public async ValueTask<JSDirectory> AddAsync(string path, string fileName, object file)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<JSDirectory> AddRangeAsync(string path, string fileName, IEnumerable<object> files)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<JSDirectory> UpdateAsync(string path, string fileName, object file)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<JSDirectory> RemoveAsync(string path, string fileName)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<JSDirectory> RemoveRangeAsync(string path, string fileName, IEnumerable<object> files)
        {
            throw new NotImplementedException();
        }

        // Get operations
        public async ValueTask<JSDirectory> ShowDirectoryPickerAsync()
        {
            return await InvokeAsync<JSDirectory>("showDirectoryPicker");
        }

        public async ValueTask<JSDirectory> ReopenLastDirectoryAsync()
        {
            return await InvokeAsync<JSDirectory>("reopenLastDirectory");
        }

        //public async ValueTask<JSFile> GetFileAsync(string path)
        //{
        //    throw new NotImplementedException("MediaFilesAccess.GetFileAsync(string path) is not yet implemented.");
        //    //return await InvokeAsync<JSFile>("getFile", path); // needs js function
        //}

        // TODO: Priority 1 - Get Files from Client
        public async ValueTask<JSFile[]> GetFilesAsync(JSDirectory directory)
        {
            return await InvokeAsync<JSFile[]>("getFiles", directory.Instance);
        }

        public async ValueTask<byte[]> DecodeAudioFileAsync(JSFile file)
        {
            return await InvokeAsync<byte[]>("decodeAudioFile", file.Name);
        }


        // Records
        public record JSDirectory(string Name, IJSObjectReference Instance) : IAsyncDisposable
        {
            // When .NET is done with this JSDirectory, also release the underlying JS object
            //public ValueTask DisposeAsync() => Instance.DisposeAsync();
            public ValueTask DisposeAsync()
            {
                return Instance.DisposeAsync();
            }
        }
        public record JSFile(string Name, long Size, DateTime LastModified, string Artist);
    }
}
