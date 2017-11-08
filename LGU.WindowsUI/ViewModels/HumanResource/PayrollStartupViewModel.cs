using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class PayrollStartupViewModel : ViewModelBase, INavigationAware
    {
        public PayrollStartupViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        
        public DelegateCommand<string> NavigateCommand { get; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // TODO:
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _HeaderEvent.Change("Payroll Startup");
        }

        private void Navigate(string view)
        {
            if (!string.IsNullOrWhiteSpace(view))
            {
                _RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, view);
            }
        }
    }
}
