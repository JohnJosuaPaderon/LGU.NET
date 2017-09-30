using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class PayrollStartupViewModel : ViewModelBase, INavigationAware
    {
        private const string TEXT_HEADER = "Payroll";

        public PayrollStartupViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            r_ChangeHeaderEvent.Publish(TEXT_HEADER);
        }
    }
}
