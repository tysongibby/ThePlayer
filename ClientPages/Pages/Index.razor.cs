using System;

using System.Linq;
using System.Threading.Tasks;
using static ClientFileApi.ClientFileAccess;
using ClientFileApi;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace ClientPages.Pages
{
    public partial class Index
    {
        // TODO: bookmark for Build an Audio Browser app with Blazor | .NET Conf 2022 https://youtu.be/2t4VwBeQ9DY?t=1317
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        internal string DirectoryName { get; set; }
        IQueryable<ClientFile> files;        
        ClientFile SelectedFile { get; set; }


        // MudGrid variables
        private string searchString;


        protected override async Task OnInitializedAsync()
        {            
            await using var dir = await ClientFiles.ReopenLastDirectoryAsync();
            if (dir is not null)
            {
                DirectoryName = dir.Name;
                files = (await ClientFiles.GetFilesAsync(dir)).AsQueryable();
            }
        }

        async Task OpenDir()
        {
            try
            {
                await using var dir = await ClientFiles.ShowDirectoryPickerAsync();
                DirectoryName = dir.Name;
                files = (await ClientFiles.GetFilesAsync(dir)).AsQueryable();
            }
            catch
            {
            // User cancelled
            }
        }

        // MudGrid methods
        // quick filter - filter gobally across multiple columns with the same input
        private Func<ClientFile, bool> quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (x.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            //if (x.Artist.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;
            return false;
        };


    }
}