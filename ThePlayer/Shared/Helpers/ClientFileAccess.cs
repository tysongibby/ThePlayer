using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ThePlayer.Shared.Helpers
{
    // requires clientFileAccess.js
    internal class ClientFileAccess : JSModuleBase
    {
        public ClientFileAccess(IJSRuntime js) : base(js, "/js/audioFileAccess.js")
        {
        }

        // CRUD operations
        public async ValueTask<JSDirectory> Add(string path, string fileName, object file)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<JSDirectory> Update(string path, string fileName, object file)
        {
            throw new NotImplementedException();
        }
        public async ValueTask<JSDirectory> Remove(string path, string fileName)
        {
            throw new NotImplementedException();
        }

        // Get operations
        public async ValueTask<JSDirectory> ShowDirectoryPicker()
        {
            return await InvokeAsync<JSDirectory>("showDirectoryPicker");
        }

        public async ValueTask<JSDirectory> ReopenLastDirectory()
        {
            return await InvokeAsync<JSDirectory>("reopenLastDirectory");
        }

        public async ValueTask<JSFile> GetFileAsync(string path)
        {
            throw new NotImplementedException("MediaFilesAccess.GetFileAsync is not yet implemented.");
            //return await InvokeAsync<JSFile>("getFile", path); // needs js function
        }

        public async ValueTask<JSFile[]> GetFilesAsync(JSDirectory directory)
        {
            return await InvokeAsync<JSFile[]>("getFiles", directory.Instance);
        }

        public async ValueTask<byte[]> DecodeAudioFileAsync(JSFile file)
        {
            return await InvokeAsync<byte[]>("decodeAudioFile", file.Name);
        }

        // Audio operations
        public async ValueTask<IJSObjectReference> PlayAudioFileAsync(JSFile file)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioFile", file.Name);
        }

        public async ValueTask<IJSObjectReference> PlayAudioDataAsync(byte[] data)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioData", data);
        }

        // Misc
        public record JSDirectory(string Name, IJSObjectReference Instance) : IAsyncDisposable
        {
            // When .NET is done with this JSDirectory, also release the underlying JS object
            public ValueTask DisposeAsync() => Instance.DisposeAsync();
        }
        public record JSFile(string Name, long Size, DateTime LastModified, string Artist);
    }
}
