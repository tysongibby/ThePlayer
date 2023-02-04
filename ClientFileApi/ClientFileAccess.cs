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
        //public ClientFileAccess(IJSRuntime js) : base(js, "./_content/ClientFileApi/js/clientFileAccess.js")
        //{
        //}
        public ClientFileAccess(IJSRuntime js) : base(js, "/js/clientFileAccess.js")
        {
        }

        // CRUD operations
        //public async ValueTask<JSDirectory> AddAsync(string path, string fileName, object file)
        //{
        //    throw new NotImplementedException();
        //}
        //public async ValueTask<JSDirectory> AddRangeAsync(string path, string fileName, IEnumerable<object> files)
        //{
        //    throw new NotImplementedException();
        //}
        //public async ValueTask<JSDirectory> UpdateAsync(string path, string fileName, object file)
        //{
        //    throw new NotImplementedException();
        //}
        //public async ValueTask<JSDirectory> RemoveAsync(string path, string fileName)
        //{
        //    throw new NotImplementedException();
        //}
        //public async ValueTask<JSDirectory> RemoveRangeAsync(string path, string fileName, IEnumerable<object> files)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public async ValueTask<JSFile> GetFileAsync(string path)
        //{
        //    throw new NotImplementedException("MediaFilesAccess.GetFileAsync(string path) is not yet implemented.");
        //    //return await InvokeAsync<JSFile>("getFile", path); // needs js function
        //}

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


        // Records
        public record JSDirectory(string Name, IJSObjectReference Instance) : IAsyncDisposable
        {
            // When .NET is done with this JSDirectory, also release the underlying JS object            
            public ValueTask DisposeAsync()
            {
                return Instance.DisposeAsync();
            }
        }
        public record ClientFile(string Name, long Size, DateTime LastModified, string Artist);
    }
}
