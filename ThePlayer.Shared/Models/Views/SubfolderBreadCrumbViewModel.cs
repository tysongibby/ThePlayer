using System.IO;

namespace ThePlayer.Shared.Models
{
    public class SubfolderBreadCrumbViewModel
    {
        public string DisplayName { get; }

        public string Path { get; }

        public SubfolderBreadCrumbViewModel(string path)
        {
            this.DisplayName = new DirectoryInfo(path).Name;
            this.Path = path;
        }
    }
}
