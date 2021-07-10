using Prism.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

//TODO: This class seems to be Windows UI specific and so is not needed
namespace ThePlayer.Shared.Models.Views
{
    public interface ISemanticZoomViewModel
    {
        ObservableCollection<ISemanticZoomable> SemanticZoomables { get; set; }

        ObservableCollection<ISemanticZoomSelector> SemanticZoomSelectors { get; set; }

        DelegateCommand<string> SemanticJumpCommand { get; set; }

        Task ShowSemanticZoomAsync();

        void HideSemanticZoom();

        void UpdateSemanticZoomHeaders();
    }
}
