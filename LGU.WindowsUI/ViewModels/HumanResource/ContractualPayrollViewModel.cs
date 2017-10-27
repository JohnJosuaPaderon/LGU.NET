using LGU.Entities.HumanResource;
using LGU.Models.HumanResource;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Linq;
using LGU.EntityManagers.HumanResource;
using System.Threading.Tasks;
using LGU.Processes;
using Prism.Interactivity.InteractionRequest;
using LGU.ViewModels.HumanResource.Dialogs;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ContractualPayrollViewModel : ViewModelBase, INavigationAware
    {
        private const string TEXT_HEADER = "Payroll - Contractual";
        private const string NAV_PARAM_PAYROLL = "payroll";
        private const string NAV_PARAM_CONTRACTUAL_PAYROLL_CLUSTER = "contractualpayrollcluster";
        private const string SEARCH_PARAM_DEPARTMENT_HEAD = "departmenthead";

        public ContractualPayrollViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _PayrollContractualDepartmentManager = ApplicationDomain.GetService<IPayrollContractualDepartmentManager>();

            BackToPayrollSetupCommand = new DelegateCommand(BackToPayrollSetup);
            ProceedCommand = new DelegateCommand(Proceed);
            RemoveEmployeeCommand = new DelegateCommand(RemoveEmployee);
            RemoveDepartmentCommand = new DelegateCommand(RemoveDepartment);
            SearchEmployeeCommand = new DelegateCommand<string>(SearchEmployee);
            SearchEmployeeRequest = new InteractionRequest<INotification>();
        }

        private readonly IPayrollContractualDepartmentManager _PayrollContractualDepartmentManager;

        public DelegateCommand BackToPayrollSetupCommand { get; }
        public DelegateCommand ProceedCommand { get; }
        public DelegateCommand RemoveEmployeeCommand { get; }
        public DelegateCommand RemoveDepartmentCommand { get; }
        public DelegateCommand<string> SearchEmployeeCommand { get; }
        public InteractionRequest<INotification> SearchEmployeeRequest { get; }

        //private ContractualPayrollClusterModel _ContractualPayrollCluster = new ContractualPayrollClusterModel(new ContractualPayrollCluster()
        //{
        //    Inclusion = new ContractualPayrollClusterInclusion()
        //});

        //public ContractualPayrollClusterModel ContractualPayrollCluster
        //{
        //    get { return _ContractualPayrollCluster; }
        //    set { SetProperty(ref _ContractualPayrollCluster, value); }
        //}

        private PayrollContractualDepartmentModel _SelectedDepartment;
        public PayrollContractualDepartmentModel SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set { SetProperty(ref _SelectedDepartment, value); }
        }

        private PayrollContractualEmployeeModel _SelectedEmployee;
        public PayrollContractualEmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value); }
        }

        private async Task TryGetDepartmentListAsync()
        {
            //if (!ContractualPayrollCluster.Departments.Any())
            //{
            //    await GetDepartmentListAsync();
            //}
        }

        private void RemoveEmployee()
        {
            if (SelectedEmployee != null)
            {
                if (SelectedDepartment != null && SelectedDepartment.Employees.Any())
                {
                    SelectedDepartment.Employees.Remove(SelectedEmployee);
                }
                else
                {
                    EnqueueMessage("Uncategorized error.");
                }
            }
            else
            {
                EnqueueMessage("No selected employee.");
            }
        }

        private void RemoveDepartment()
        {
            //if (SelectedDepartment != null)
            //{
            //    if (ContractualPayrollCluster.Departments.Any())
            //    {
            //        ContractualPayrollCluster.Departments.Remove(SelectedDepartment);
            //    }
            //    else
            //    {
            //        EnqueueMessage("Uncategorized error.");
            //    }
            //}
            //else
            //{
            //    EnqueueMessage("No selected department.");
            //}
        }

        private void SearchEmployee(string searchParam)
        {
            switch (searchParam)
            {
                case SEARCH_PARAM_DEPARTMENT_HEAD:
                    SearchEmployeeRequest.Raise(new Notification() { Title = string.Empty, Content = new EmployeeSearchDialogContent() });
                    break;
                default:
                    break;
            }
        }

        private async Task GetDepartmentListAsync()
        {
            //ContractualPayrollCluster.Departments.Clear();

            //var result = await _PayrollContractualDepartmentManager.GenerateListAsync(ContractualPayrollCluster.Payroll.RangeDate.GetSource());

            //if (result.Status == ProcessResultStatus.Success)
            //{
            //    if (result.DataList != null && result.DataList.Any())
            //    {
            //        foreach (var item in result.DataList)
            //        {
            //            ContractualPayrollCluster.Departments.Add(new PayrollContractualDepartmentModel(item));
            //        }
            //    }
            //}
            //else
            //{
            //    EnqueueMessage(result.Message);
            //}
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
            //ContractualPayrollCluster.Payroll = navigationContext.Parameters[NAV_PARAM_PAYROLL] as PayrollContractualModel;
            //_ChangeHeaderEvent.Publish(TEXT_HEADER);

            //await TryGetDepartmentListAsync();
        }

        private void BackToPayrollSetup()
        {
            //var parameters = new NavigationParameters
            //{
            //    { NAV_PARAM_PAYROLL, ContractualPayrollCluster.Payroll }
            //};

            //_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(PayrollStartupView), parameters);
        }

        private void Proceed()
        {
            //var parameters = new NavigationParameters
            //{
            //    { NAV_PARAM_CONTRACTUAL_PAYROLL_CLUSTER, ContractualPayrollCluster }
            //};

            //_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(ContractualPayrollFinishView), parameters);
        }
    }
}
