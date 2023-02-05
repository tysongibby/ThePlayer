using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static ClientFileApi.ClientFileAccess;

namespace ClientFileApi
{
    // requires clientFileAccess.js
    public class ClientFileAccess : JSModuleBase
    {
        public ClientFileAccess(IJSRuntime js) : base(js, "./_content/ClientFileApi/js/clientFileAccess.js")
        {
        }

        // Get operations
        public async ValueTask<JSDirectory> ShowDirectoryPickerAsync()
        {
            try
            {
                return await InvokeAsync<JSDirectory>("showDirectoryPicker");
            }
            catch (Exception e)
            {
                throw new DirectoryNotFoundException(e.Message, e);
            }
        }

        public async ValueTask<JSDirectory> ReopenLastDirectoryAsync()
        {
            try
            {
                return await InvokeAsync<JSDirectory>("reopenLastDirectory");
            }
            catch (Exception e)
            {
                throw new DirectoryNotFoundException(e.Message, e);
            }
        }

        // Get Files from Client
        public async ValueTask<ClientFile[]> GetFilesAsync(JSDirectory directory)
        {
            if (directory == null)
            {
                throw new ArgumentNullException(nameof(directory));
            }

            try
            {
                return await InvokeAsync<ClientFile[]>("getFiles", directory.Instance);
            }
            catch (Exception e)
            {
                throw new DirectoryNotFoundException(e.Message, e);
            }
        }

        // Audio player functions
        public async ValueTask<IJSObjectReference> PlayAudioFileAsync(ClientFile file)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioFile", file.Name);
        }

        public async ValueTask<IJSObjectReference> PlayAudioDataAsync(byte[] data)
        {
            return await InvokeAsync<IJSObjectReference>("playAudioData", data);
        }

        public async ValueTask<byte[]> DecodeAudioFileAsync(ClientFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            try
            {
                return await InvokeAsync<byte[]>("decodeAudioFile", file.Name);
            }
            catch (Exception e)
            {
                throw new FileNotFoundException(e.Message, e);
            }
        }


        // Records
        public record JSDirectory(string Name, IJSObjectReference Instance) : IAsyncDisposable
        {
            // When .NET is done with this JSDirectory, also release the underlying JS object            
            public ValueTask DisposeAsync()
            {
                return Instance.DisposeAsync();
            }
        }
        public record ClientFile(string Name, long Size, string RelativePath);
    }
}
