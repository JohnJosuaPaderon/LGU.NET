using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
            _PayrollContractualEmployeeManager = ApplicationDomain.GetService<IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction>>();
            _Employees = new List<IPayrollContractualEmployee>();

            BackToPayrollSetupCommand = new DelegateCommand(BackToPayrollSetup);
            Departments = new ObservableCollection<DepartmentModel>();
            Employees = new ObservableCollection<PayrollContractualEmployeeModel>();
        }

        private readonly IEmployeeManager _EmployeeManager;
        private readonly IPayrollContractualEmployeeManager<SqlConnection, SqlTransaction> _PayrollContractualEmployeeManager;
        private readonly List<IPayrollContractualEmployee> _Employees;

        public DelegateCommand BackToPayrollSetupCommand { get; }

        public ObservableCollection<DepartmentModel> Departments { get; }
        public ObservableCollection<PayrollContractualEmployeeModel> Employees { get; }

        private ContractualPayrollClusterModel _ContractualPayrollCluster = new ContractualPayrollClusterModel(new ContractualPayrollCluster()
        {
            Inclusion = new ContractualPayrollClusterInclusion()
        });

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

            var result = await _PayrollContractualEmployeeManager.GenerateListAsync(_ContractualPayrollCluster.Payroll.RangeDate.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    _Employees.AddRange(result.DataList);
                    ExtractDepartmentList();
                }
            }
            else
            {
                r_NewMessageEvent.Publish(result.Message); 
            }
            
        }

        private void ExtractDepartmentList()
        {
            Departments.Clear();

            foreach (var employee in _Employees)
            {
                var department = new DepartmentModel(employee.Employee?.Department);

                if (!Departments.Contains(department))
                {
                    Departments.Add(department);
                }
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ContractualPayrollCluster.Payroll = navigationContext.Parameters[NAV_PARAM_PAYROLL] as PayrollModel;
            r_ChangeHeaderEvent.Publish(TEXT_HEADER);

            await TryGetEmployeeListAsync();
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
