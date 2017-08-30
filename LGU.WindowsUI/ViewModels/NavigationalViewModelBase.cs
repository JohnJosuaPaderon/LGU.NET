using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace LGU.ViewModels
{
    public abstract class NavigationalViewModelBase : ViewModelBase
    {
        public NavigationalViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator, string navigationTargetRegion) : base(regionManager, eventAggregator)
        {
            MenuWidth = 350;
            NavigateCommand = new DelegateCommand(Navigate);
            NavigationTargetRegion = navigationTargetRegion;
        }

        public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();
        public DelegateCommand NavigateCommand { get; }

        protected string NavigationTargetRegion { get; }

        private bool _IsMenuOpen;
        public bool IsMenuOpen
        {
            get { return _IsMenuOpen; }
            set { SetProperty(ref _IsMenuOpen, value); }
        }

        private MenuItem _SelectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return _SelectedMenuItem; }
            set { SetProperty(ref _SelectedMenuItem, value); }
        }

        private double _MenuWidth;
        public double MenuWidth
        {
            get { return _MenuWidth; }
            set { SetProperty(ref _MenuWidth, value); }
        }

        private void Navigate()
        {
            r_RegionManager.RequestNavigate(NavigationTargetRegion, SelectedMenuItem.ViewName);
            IsMenuOpen = false;
        }
    }
}
