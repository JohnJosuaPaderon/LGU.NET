using System;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class MainViewModel : ViewModelBase, INavigationAware
    {
        public static string MainViewContentRegion => "MainViewContentRegion";

        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }

        private bool _IsMenuOpen;
        public bool IsMenuOpen
        {
            get { return _IsMenuOpen; }
            set { SetProperty(ref _IsMenuOpen, value); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            RegionManager.RequestNavigate(MainViewContentRegion, (string)navigationContext.Parameters["view"]);
        }
    }
}
