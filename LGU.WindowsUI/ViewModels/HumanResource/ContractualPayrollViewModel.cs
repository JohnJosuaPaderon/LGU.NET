using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Interactivity;
using LGU.Interactivity.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ContractualPayrollViewModel : ViewModelBase, INavigationAware
    {
        private const string TEXT_HEADER = "Payroll - Contractual";
        private const string NAV_PARAM_PAYROLL = "payroll";
        private const string SEARCH_PARAM_DEPARTMENT_HEAD = "departmenthead";

        public ContractualPayrollViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _DepartmentManager = ApplicationDomain.GetService<IPayrollContractualDepartmentManager>();
            _PayrollManager = ApplicationDomain.GetService<IPayrollContractualManager>();

            ChangeCutOffCommand = new DelegateCommand(ChangeCutOff);
            SearchEmployeeCommand = new DelegateCommand<string>(SearchEmployee);
            RemoveSelectedDepartmentCommand = new DelegateCommand(RemoveSelectedDepartment);
            RemoveSelectedEmployeeCommand = new DelegateCommand(RemoveSelectedEmployee);
            EditSignatoryCommand = new DelegateCommand(EditSignatory);
            SaveCommand = new DelegateCommand(Save);
            ChangeCutOffRequest = new InteractionRequest<IDateTimeRangeSelectionNotification>();
            SearchEmployeeRequest = new InteractionRequest<IEmployeeSearchNotification>();
            EditSignatoryRequest = new InteractionRequest<IContractualPayrollSignatoryNotification>();
        }

        private readonly IPayrollContractualDepartmentManager _DepartmentManager;
        private readonly IPayrollContractualManager _PayrollManager;

        public DelegateCommand ChangeCutOffCommand { get; }
        public DelegateCommand<string> SearchEmployeeCommand { get; }
        public DelegateCommand RemoveSelectedDepartmentCommand { get; }
        public DelegateCommand RemoveSelectedEmployeeCommand { get; }
        public DelegateCommand EditSignatoryCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public InteractionRequest<IDateTimeRangeSelectionNotification> ChangeCutOffRequest { get; }
        public InteractionRequest<IEmployeeSearchNotification> SearchEmployeeRequest { get; }
        public InteractionRequest<IContractualPayrollSignatoryNotification> EditSignatoryRequest { get; }

        private PayrollContractualModel _Payroll;
        public PayrollContractualModel Payroll
        {
            get { return _Payroll; }
            set { SetProperty(ref _Payroll, value); }
        }

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

        protected override void Initialize()
        {
            if (Payroll == null)
            {
                Payroll = new PayrollContractualModel(new PayrollContractual()
                {
                    RangeDate = new ValueRange<DateTime>(DateTime.Now.AddDays(-15), DateTime.Now)
                });
            }
        }

        private void ChangeCutOff()
        {
            ChangeCutOffRequest.Raise(new DateTimeRangeSelectionNotification("Select Cut-Off", Payroll.RangeDate), GenerateDepartmentList);
        }

        private void SearchEmployee(string searchKey)
        {
            switch (searchKey)
            {
                case SEARCH_PARAM_DEPARTMENT_HEAD:
                    SearchDepartmentHead();
                    break;
                default:
                    break;
            }
        }

        private void SearchDepartmentHead()
        {
            if (SelectedDepartment != null)
            {
                SearchEmployeeRequest.Raise(new EmployeeSearchNotification("Search Department Head...", SEARCH_PARAM_DEPARTMENT_HEAD, SelectedDepartment.Head), DepartmentHeadSearchCallback);
            }
            else
            {
                _NewMessageEvent.EnqueueMessage("No selected department.");
            }
        }

        private void RemoveSelectedDepartment()
        {
            if (SelectedDepartment != null)
            {
                if (Payroll.Departments.Count > 0)
                {
                    Payroll.Departments.Remove(SelectedDepartment);
                } 
            }
            else
            {
                _NewMessageEvent.EnqueueMessage("No selected department.");
            }
        }

        private void RemoveSelectedEmployee()
        {
            if (SelectedEmployee != null)
            {
                if (SelectedDepartment != null && SelectedDepartment.Employees.Count > 0)
                {
                    SelectedDepartment.Employees.Remove(SelectedEmployee);
                }
            }
            else
            {
                _NewMessageEvent.EnqueueMessage("No selected employee.");
            }
        }

        private void EditSignatory()
        {
            EditSignatoryRequest.Raise(new ContractualPayrollSignatoryNotification(Payroll));
        }

        private void DepartmentHeadSearchCallback(IEmployeeSearchNotification notification)
        {
            SelectedDepartment.Head = notification.SelectedEmployee;
        }

        private async void GenerateDepartmentList(IDateTimeRangeSelectionNotification notification)
        {
            _BusyAppEvent.Busy();

            var result = await _DepartmentManager.GenerateListAsync(notification.DateTimeRange.GetSource());

            Payroll.Departments.Clear();

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var department in result.DataList)
                    {
                        department.Payroll = Payroll.GetSource();
                        Payroll.Departments.Add(PayrollContractualDepartmentModel.TryCreate(department));
                    }
                }
            }
            else
            {
                _NewMessageEvent.EnqueueErrorMessage(result.Message);
            }

            _BusyAppEvent.Unbusy();
        }

        private async void Save()
        {
            _BusyAppEvent.Busy();

            if (Payroll != null)
            {
                var result = await _PayrollManager.InsertAsync(Payroll.GetSource());

                if (result.Status == ProcessResultStatus.Success)
                {
                    _NewMessageEvent.EnqueueMessage("Payroll successfully created.");
                }
                else
                {
                    _NewMessageEvent.EnqueueMessage(result.Message);
                }
            }

            _BusyAppEvent.Unbusy();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _HeaderEvent.Change("Payroll Contractual");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
