using LGU.Core.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace LGU.HumanResource.ViewModels
{
    public class ContentSelectionViewModel : BindableBase
    {
        private IRegionManager RegionManager { get; }

        public ContentSelectionViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            NavigateWindowCommand = new DelegateCommand<string>(NavigateWindow);
        }

        private void Navigate(string target)
        {
            RegionManager.RequestNavigate(MainWindowViewModel.CONTENT_REGION, target);
        }
        
        private void NavigateWindow(string target)
        {
            RegionManager.RequestNavigate(MainWindowViewModel.CONTENT_REGION, target);
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> NavigateWindowCommand { get; private set; }
    }
}
