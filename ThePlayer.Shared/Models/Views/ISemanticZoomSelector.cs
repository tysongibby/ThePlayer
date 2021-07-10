//TODO: This class seems to be Windows UI specific and so is not needed

namespace ThePlayer.Shared.Models.Views
{
    public interface ISemanticZoomSelector
    {
        string Header { get; set; }

        bool CanZoom { get; set; }
    }
}
