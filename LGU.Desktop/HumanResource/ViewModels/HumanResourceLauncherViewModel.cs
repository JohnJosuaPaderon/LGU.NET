using LGU.Core.Events;
using LGU.HumanResource.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace LGU.HumanResource.ViewModels
{
    public class HumanResourceLauncherViewModel : BindableBase, INavigationAware
    {
        public const string CONTENT_REGION = "HumanResource_ContentRegion";

        public HumanResourceLauncherViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;

            RegionManager.Regions.Remove(CONTENT_REGION);
        }

        private IRegionManager RegionManager { get; }
        private IEventAggregator EventAggregator { get; }

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

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            EventAggregator.GetEvent<WindowTitleEvent>().Publish("You're now at Human Resource");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
