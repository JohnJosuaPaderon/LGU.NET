using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.Views.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditEmployeeDialogViewModel : DialogViewModelBase
    {
        public AddEditEmployeeDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            r_DepartmentManager = ApplicationDomain.GetService<IDepartmentManager>();
            r_SalaryGradeStepManager = ApplicationDomain.GetService<ISalaryGradeStepManager>();
            r_EmployeeSalaryGradeStepManager = ApplicationDomain.GetService<IEmployeeSalaryGradeStepManager>();
            r_WorkTimeScheduleManager = ApplicationDomain.GetService<IWorkTimeScheduleManager>();
            r_EmployeeTypeManager = ApplicationDomain.GetService<IEmployeeTypeManager>();

            SaveCommand = new DelegateCommand(Save);
            OpenPdsCommand = new DelegateCommand(OpenPds);

            r_AddEmployeeEvent = r_EventAggregator.GetEvent<AddEmployeeEvent>();
            r_EditEmployeeEvent = r_EventAggregator.GetEvent<EditEmployeeEvent>();

            Departments = new ObservableCollection<DepartmentModel>();
            WorkTimeSchedules = new ObservableCollection<WorkTimeScheduleModel>();
            Types = new ObservableCollection<EmployeeTypeModel>();

            Initialize();
        }

        private readonly IEmployeeManager r_EmployeeManager;
        private readonly IDepartmentManager r_DepartmentManager;
        private readonly ISalaryGradeStepManager r_SalaryGradeStepManager;
        private readonly IEmployeeSalaryGradeStepManager r_EmployeeSalaryGradeStepManager;
        private readonly IEmployeeTypeManager r_EmployeeTypeManager;
        private readonly IWorkTimeScheduleManager r_WorkTimeScheduleManager;
        private readonly AddEmployeeEvent r_AddEmployeeEvent;
        private readonly EditEmployeeEvent r_EditEmployeeEvent;

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand OpenPdsCommand { get; }
        public ObservableCollection<DepartmentModel> Departments { get; }
        public ObservableCollection<WorkTimeScheduleModel> WorkTimeSchedules { get; }
        public ObservableCollection<EmployeeTypeModel> Types { get; }

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value, OnEmployeeChanged); }
        }

        private bool _Multiple;
        public bool Multiple
        {
            get { return _Multiple; }
            set { SetProperty(ref _Multiple, value); }
        }

        private int? _SalaryGradeNumber;
        public int? SalaryGradeNumber
        {
            get { return _SalaryGradeNumber; }
            set { SetProperty(ref _SalaryGradeNumber, value, GetSalaryGradeStep); }
        }

        private int? _Step;
        public int? Step
        {
            get { return _Step; }
            set { SetProperty(ref _Step, value, GetSalaryGradeStep); }
        }

        private SalaryGradeStepModel _SalaryGradeStep;
        public SalaryGradeStepModel SalaryGradeStep
        {
            get { return _SalaryGradeStep; }
            set { SetProperty(ref _SalaryGradeStep, value); }
        }

        protected async override void Initialize()
        {
            base.Initialize();

            r_AddEmployeeEvent.Subscribe(e => SetData(e, "Add new Employee", DialogMode.Add));
            r_EditEmployeeEvent.Subscribe(e => SetData(e, "Edit Employee", DialogMode.Edit));

            await GetDepartmentListAsync();
            await GetEmployeeTypeListAsync();
            await GetWorkTimeScheduleListAsync();
        }

        private async Task GetEmployeeTypeListAsync()
        {
            var result = await r_EmployeeTypeManager.GetListAsync();
            Types.Clear();

            if (result.Status == ProcessResultStatus.Success && result.DataList != null)
            {
                foreach (var type in result.DataList)
                {
                    Types.Add(new EmployeeTypeModel(type));
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }

        private async Task GetDepartmentListAsync()
        {
            var result = await r_DepartmentManager.GetListAsync();
            Departments.Clear();

            if (result.Status == ProcessResultStatus.Success && result.DataList != null)
            {
                foreach (var department in result.DataList)
                {
                    Departments.Add(new DepartmentModel(department));
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }

        private async Task GetWorkTimeScheduleListAsync()
        {
            var result = await r_WorkTimeScheduleManager.GetListAsync();
            WorkTimeSchedules.Clear();

            if (result.Status == ProcessResultStatus.Success && result.DataList != null)
            {
                foreach (var workTimeSchedule in result.DataList)
                {
                    WorkTimeSchedules.Add(new WorkTimeScheduleModel(workTimeSchedule));
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }

        private void SetData(EmployeeModel employee, string headerTitle, DialogMode mode)
        {
            Employee = employee;
            HeaderTitle = headerTitle;
            Mode = mode;
        }

        private async void OnEmployeeChanged()
        {
            if (Employee != null)
            {
                var salaryGradeStepResult = await r_SalaryGradeStepManager.GetCurrentByEmployeeAsync(Employee.GetSource());

                if (salaryGradeStepResult.Status == ProcessResultStatus.Success)
                {
                    SalaryGradeNumber = salaryGradeStepResult.Data?.SalaryGrade?.Number;
                    Step = salaryGradeStepResult.Data?.Step;
                }
                else
                {
                    EnqueueMessage(salaryGradeStepResult.Message);
                }
            }
            else
            {
                SalaryGradeNumber = null;
                Step = null;
            }
        }

        private async void GetSalaryGradeStep()
        {
            if (SalaryGradeNumber != null && SalaryGradeNumber > 0 && Step != null && Step > 0)
            {
                var result = await r_SalaryGradeStepManager.GetByNumberAndStepAsync(SalaryGradeNumber ?? 0, Step ?? 0);

                if (result.Status == ProcessResultStatus.Success)
                {
                    if (result.Data != null)
                    {
                        SalaryGradeStep = new SalaryGradeStepModel(result.Data);
                    }
                    else
                    {
                        SalaryGradeStep = null;
                    }
                }
                else
                {
                    EnqueueMessage(result.Message);
                }
            }
            else
            {
                    SalaryGradeStep = null;
            }
        }

        private void OpenPds()
        {
            var parameters = new NavigationParameters
            {
                { "employee", Employee }
            };
            DialogHelper.CloseDialog();

            r_RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(PersonalDataSheetView), parameters);
        }

        private async void Save()
        {
            switch (Mode)
            {
                case DialogMode.Add:
                    await InsertAsync();
                    break;
                case DialogMode.Edit:
                    await UpdateAsync();
                    break;
            }
        }

        private async Task InsertAsync()
        {
            var employeeResult = await r_EmployeeManager.InsertAsync(Employee.GetSource());

            if (employeeResult.Status == ProcessResultStatus.Success)
            {
                await InsertEmployeeSalaryGradeStepAsync(employeeResult.Data);

                if (Multiple)
                {
                    Employee = new EmployeeModel(new Employee());
                }
                else
                {
                    DialogHelper.CloseDialog();
                }

                EnqueueMessage("Employee has been added successfully.");
            }
            else if (employeeResult.Status == ProcessResultStatus.Failed)
            {
                EnqueueMessage($"Failed to add new employee. {employeeResult.Message}");
            }
        }
                        
        private async Task UpdateAsync()
        {
            var result = await r_EmployeeManager.UpdateAsync(Employee.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                await InsertEmployeeSalaryGradeStepAsync(result.Data);

                DialogHelper.CloseDialog();
                EnqueueMessage("Employee details has been updated successfully.");
            }
            else if (result.Status == ProcessResultStatus.Failed)
            {
                EnqueueMessage($"Failed to update employee. {result.Message}");
            }
        }

        private async Task InsertEmployeeSalaryGradeStepAsync(IEmployee employee)
        {
            if (SalaryGradeStep != null)
            {
                var employeeSalaryGradeStep = new EmployeeSalaryGradeStep
                {
                    Employee = employee,
                    SalaryGradeStep = SalaryGradeStep.GetSource(),
                    EffectivityDate = DateTime.Now
                };

                var result = await r_EmployeeSalaryGradeStepManager.InsertAsync(employeeSalaryGradeStep);

                if (result.Status == ProcessResultStatus.Failed)
                {
                    EnqueueMessage(result.Message);
                }
            }
        }
    }
}
