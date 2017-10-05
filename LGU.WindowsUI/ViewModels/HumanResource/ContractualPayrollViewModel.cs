using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ContractualPayrollViewModel : ViewModelBase, INavigationAware
    {
        private const string TEXT_HEADER = "Payroll - Contractual";
        private const string NAV_PARAM_PAYROLL = "payroll";

        public ContractualPayrollViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();

            BackToPayrollSetupCommand = new DelegateCommand(BackToPayrollSetup);
        }

        private readonly IEmployeeManager _EmployeeManager;

        public DelegateCommand BackToPayrollSetupCommand { get; }

        private ContractualPayrollClusterModel _ContractualPayrollCluster = new ContractualPayrollClusterModel(null);
        public ContractualPayrollClusterModel ContractualPayrollCluster
        {
            get { return _ContractualPayrollCluster; }
            set { SetProperty(ref _ContractualPayrollCluster, value); }
        }

        private async Task TryGetEmployeeListAsync()
        {
            if (!ContractualPayrollCluster.Employees.Any())
            {
                await GetEmployeeListAsync();
            }
        }

        private async Task GetEmployeeListAsync()
        {
            ContractualPayrollCluster.Employees.Clear();

            var result = await _EmployeeManager.GetListByPayrollTypeAsync(ContractualPayrollCluster.Payroll.Type.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    
                }
            }
            else
            {
                r_NewMessageEvent.Publish(result.Message); 
            }
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
            ContractualPayrollCluster.Payroll = navigationContext.Parameters[NAV_PARAM_PAYROLL] as PayrollModel;
            r_ChangeHeaderEvent.Publish(TEXT_HEADER);
        }

        private void BackToPayrollSetup()
        {
            var parameters = new NavigationParameters
            {
                { NAV_PARAM_PAYROLL, ContractualPayrollCluster.Payroll }
            };

            r_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(PayrollStartupView), parameters);
        }
    }
}
