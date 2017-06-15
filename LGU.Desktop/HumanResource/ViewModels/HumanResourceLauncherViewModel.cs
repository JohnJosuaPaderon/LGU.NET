using LGU.HumanResource.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace LGU.HumanResource.ViewModels
{
    public class HumanResourceLauncherViewModel : BindableBase
    {
        public const string CONTENT_REGION = "HumanResource_ContentRegion";

        public HumanResourceLauncherViewModel(IRegionManager regionManager)
        {
            RegionManager = regionManager;
        }

        private IRegionManager RegionManager { get; }

        private bool _IsMenuOpen;
        public bool IsMenuOpen
        {
            get { return _IsMenuOpen; }
            set { SetProperty(ref _IsMenuOpen, value); }
        }


        private DelegateCommand<string> _NavigateCommand;
        public DelegateCommand<string> NavigateCommand =>
            _NavigateCommand ?? (_NavigateCommand = new DelegateCommand<string>(Navigate));

        private void Navigate(string target)
        {
            RegionManager.RequestNavigate(CONTENT_REGION, target);
        }

        public void Initialize()
        {
            Navigate(nameof(ContentSelectionView));
        }
    }
}
