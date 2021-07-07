using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThePlayer.Shared.Log;
using ThePlayer.Shared.Models;
using ThePlayer.Share.Io;

namespace ThePlayer.Ui.Shared
{
    public partial class FileIndex
    {
        //retrieve files from music folder and display in a list.

        //IEnumerable<string> fileList = Directory.GetFiles(@"C:\Users\Tyson Gibby\OneDrive\Music\a-ha", "*.mp3");
        private IEnumerable<string> fileList;

        public FileIndex()
        {
            fileList = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        }

        public List<string> FileList 
        {
            get 
            {
                return fileList.ToList();
            }
            set
            { 
                fileList = value;
            }
        }

        private async void AddFolder(string fileName)
        {
            LogClient.Info("Adding a folder to the collection.");

            

     
            try
                {
                    //this.IsLoadingFolders = true;

                    AddFolderResult result = AddFolderResult.Error; // Initial value

                    // First, check if the folder's content is accessible. If not, don't add the folder.
                    if (FileOperations.IsDirectoryContentAccessible(fileName))
                    {
                        result = await this.foldersService.AddFolderAsync(fileName);
                    }
                    else
                    {
                        result = AddFolderResult.Inaccessible;
                    }

                    //this.IsLoadingFolders = false;

                    switch (result)
                    {
                        case AddFolderResult.Success:
                            this.indexingService.OnFoldersChanged();
                            this.GetFoldersAsync();
                            break;
                        case AddFolderResult.Error:
                            this.dialogService.ShowNotification(
                                0xe711,
                                16,
                                ResourceUtils.GetString("Language_Error"),
                                ResourceUtils.GetString("Language_Error_Adding_Folder"),
                                ResourceUtils.GetString("Language_Ok"),
                                true,
                                ResourceUtils.GetString("Language_Log_File"));
                            break;
                        case AddFolderResult.Duplicate:

                            this.dialogService.ShowNotification(
                                0xe711,
                                16,
                                ResourceUtils.GetString("Language_Already_Exists"),
                                ResourceUtils.GetString("Language_Folder_Already_In_Collection"),
                                ResourceUtils.GetString("Language_Ok"),
                                false,
                                "");
                            break;
                        case AddFolderResult.Inaccessible:

                            this.dialogService.ShowNotification(
                                0xe711,
                                16,
                                ResourceUtils.GetString("Language_Error"),
                                ResourceUtils.GetString("Language_Folder_Could_Not_Be_Added_Check_Permissions").Replace("{foldername}", fileName),
                                ResourceUtils.GetString("Language_Ok"),
                                false,
                                "");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LogClient.Error("Exception: {0}", ex.Message);

                    this.dialogService.ShowNotification(
                        0xe711,
                        16,
                        ResourceUtils.GetString("Language_Error"),
                        ResourceUtils.GetString("Language_Error_Adding_Folder"),
                        ResourceUtils.GetString("Language_Ok"),
                        true,
                        ResourceUtils.GetString("Language_Log_File"));
                }
                finally
                {
                    this.IsLoadingFolders = false;
                }
            
        }
    }
}
