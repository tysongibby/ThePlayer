﻿using ThePlayer.Shared.Models.Views;
using ThePlayer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ThePlayer.Shared.Services.FolderService
{
    public interface IFoldersService
    {
        event EventHandler FoldersChanged;

        Task ToggleFolderAsync(FolderViewModel folder);

        Task SaveToggledFoldersAsync();

        Task<IList<FolderViewModel>> GetFoldersAsync();

        Task<AddFolderResult> AddFolderAsync(string path);

        Task<RemoveFolderResult> RemoveFolderAsync(long folderId);

        Task<FolderViewModel> GetSelectedFolderAsync();

        Task<IList<SubfolderViewModel>> GetSubfoldersAsync(FolderViewModel selectedRootFolder, SubfolderViewModel selectedSubfolder);

        IList<SubfolderBreadCrumbViewModel> GetSubfolderBreadCrumbs(FolderViewModel selectedRootFolder, string path);

        Task SetPlayingSubFolderAsync(IEnumerable<SubfolderViewModel> subfolderViewModels);
    }
}
