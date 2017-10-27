using LGU.Models.HumanResource;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ContractualPayrollFinishViewModel : ViewModelBase, INavigationAware
    {
        private const string NAV_PARAM_CONTRACTUAL_PAYROLL_CLUSTER = "contractualpayrollcluster";
        private const string NAV_PARAM_PAYROLL = "payroll";

        public ContractualPayrollFinishViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            BackToPreviousCommand = new DelegateCommand(BackToPrevious);
        }

        public DelegateCommand BackToPreviousCommand { get; }

        private int _EmployeeCount;
        public int EmployeeCount
        {
            get { return _EmployeeCount; }
            set { SetProperty(ref _EmployeeCount, value); }
        }

        protected override void Initialize()
        {
            CountEmployees();
        }

        private void CountEmployees()
        {
            //if (ContractualPayrollCluster != null)
            //{
            //    var count = 0;

            //    foreach (var department in ContractualPayrollCluster.Departments)
            //    {
            //        count += department.Employees.Count;
            //    }

            //    EmployeeCount = count;
            //}
        }

        private void BackToPrevious()
        {
            //var parameters = new NavigationParameters
            //{
            //    { NAV_PARAM_PAYROLL, ContractualPayrollCluster.Payroll }
            //};

            //_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(ContractualPayrollView), parameters);
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
            //ContractualPayrollCluster = navigationContext.Parameters[NAV_PARAM_CONTRACTUAL_PAYROLL_CLUSTER] as ContractualPayrollClusterModel;
        }
    }
}
