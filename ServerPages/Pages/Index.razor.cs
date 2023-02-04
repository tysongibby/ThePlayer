using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using ServerPages;
using MudBlazor;
using static ClientFileApi.ClientFileAccess;
using NeoSmart.PrettySize;
using ClientFileApi;

namespace ServerPages.Pages
{
    public partial class Index
    {       
        // TODO: bookmark for Build an Audio Browser app with Blazor | .NET Conf 2022 https://youtu.be/2t4VwBeQ9DY?t=1317
        
        internal string DirectoryName { get; set; }
        IQueryable<ClientFileAccess.ClientFile> files;        
        ClientFile SelectedFile { get; set; }

        // MudGrid variables
        private string searchString;


        //protected override async Task OnInitializedAsync()
        //{
        //// TODO: JSInterop doesn't work in Prerender methods in net 6? (only in .NET 7?)
        //await using var dir = await ClientFiles.ReopenLastDirectoryAsync();
        //if (dir is not null)
        //{
        //    name = dir.Name;
        //    files = (await ClientFiles.GetFilesAsync(dir)).AsQueryable();
        //}
        //}

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

        public void PlayAudioFile(ClientFile audioFile)
        {

        }

        public void SelectFile()
        {

        }
    }
}