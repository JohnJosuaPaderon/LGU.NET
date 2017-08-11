using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class KioskServiceSelectionViewModel : ViewModelBase
    {
        public KioskServiceSelectionViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private void Navigate(string viewName)
        {
            r_RegionManager.RequestNavigate(MainKioskViewModel.KioskContentRegion, viewName);
        }
    }
}
