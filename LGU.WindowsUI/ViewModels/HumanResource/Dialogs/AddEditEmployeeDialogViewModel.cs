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
            _EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            _DepartmentManager = ApplicationDomain.GetService<IDepartmentManager>();
            _SalaryGradeStepManager = ApplicationDomain.GetService<ISalaryGradeStepManager>();
            _EmployeeSalaryGradeStepManager = ApplicationDomain.GetService<IEmployeeSalaryGradeStepManager>();
            _WorkTimeScheduleManager = ApplicationDomain.GetService<IWorkTimeScheduleManager>();
            _EmployeeTypeManager = ApplicationDomain.GetService<IEmployeeTypeManager>();
            _EmployeeWorkdayScheduleManager = ApplicationDomain.GetService<IEmployeeWorkdayScheduleManager>();

            _AddEmployeeEvent = _EventAggregator.GetEvent<AddEmployeeEvent>();
            _EditEmployeeEvent = _EventAggregator.GetEvent<EditEmployeeEvent>();

            SaveCommand = new DelegateCommand(Save);
            OpenPdsCommand = new DelegateCommand(OpenPds);
            Departments = new ObservableCollection<DepartmentModel>();
            WorkTimeSchedules = new ObservableCollection<WorkTimeScheduleModel>();
            Types = new ObservableCollection<EmployeeTypeModel>();

            _AddEmployeeEvent.Subscribe(e => SetData(e, "Add new Employee", DialogMode.Add));
            _EditEmployeeEvent.Subscribe(e => SetData(e, "Edit Employee", DialogMode.Edit));

            Initialize();
        }

        private readonly IEmployeeManager _EmployeeManager;
        private readonly IDepartmentManager _DepartmentManager;
        private readonly ISalaryGradeStepManager _SalaryGradeStepManager;
        private readonly IEmployeeSalaryGradeStepManager _EmployeeSalaryGradeStepManager;
        private readonly IEmployeeTypeManager _EmployeeTypeManager;
        private readonly IWorkTimeScheduleManager _WorkTimeScheduleManager;
        private readonly IEmployeeWorkdayScheduleManager _EmployeeWorkdayScheduleManager;
        private readonly AddEmployeeEvent _AddEmployeeEvent;
        private readonly EditEmployeeEvent _EditEmployeeEvent;

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

        private EmployeeWorkdayScheduleModel _WorkdaySchedule;
        public EmployeeWorkdayScheduleModel WorkdaySchedule
        {
            get { return _WorkdaySchedule; }
            set { SetProperty(ref _WorkdaySchedule, value); }
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

            await TryGetDepartmentListAsync();
            await TryGetEmployeeTypeListAsync();
            await TryGetWorkTimeScheduleListAsync();
        }

        private async Task TryGetDepartmentListAsync()
        {
            if (Departments.Count <= 0)
            {
                await GetDepartmentListAsync();
            }
        }

        private async Task TryGetEmployeeTypeListAsync()
        {
            if (Types.Count <= 0)
            {
                await GetEmployeeTypeListAsync();
            }
        }

        private async Task TryGetWorkTimeScheduleListAsync()
        {
            if (WorkTimeSchedules.Count <= 0)
            {
                await GetWorkTimeScheduleListAsync();
            }
        }

        private async Task GetEmployeeTypeListAsync()
        {
            var result = await _EmployeeTypeManager.GetListAsync();
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
            var result = await _DepartmentManager.GetListAsync();
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
            var result = await _WorkTimeScheduleManager.GetListAsync();
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
                var employee = Employee.GetSource();

                await GetCurrentSalaryGradeStepByEmployeeAsync(employee);
                await GetWorkdayScheduleByEmployeeAsync(employee);
            }
            else
            {
                SalaryGradeNumber = null;
                Step = null;
            }
        }

        private async Task GetCurrentSalaryGradeStepByEmployeeAsync(IEmployee employee)
        {
            var salaryGradeStepResult = await _SalaryGradeStepManager.GetCurrentByEmployeeAsync(employee);

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

        private async Task GetWorkdayScheduleByEmployeeAsync(IEmployee employee)
        {
            var result = await _EmployeeWorkdayScheduleManager.GetByEmployeeAsync(employee);

            if (result.Status == ProcessResultStatus.Success && result.Data != null)
            {
                WorkdaySchedule = new EmployeeWorkdayScheduleModel(result.Data);
            }
            else
            {
                WorkdaySchedule = new EmployeeWorkdayScheduleModel(new EmployeeWorkdaySchedule
                {
                    Employee = employee,
                    Sunday = true,
                    Monday = true,
                    Tuesday = true,
                    Wednesday = true,
                    Thursday = true,
                    Friday = true,
                    Saturday = true
                });
            }
        }

        private async void GetSalaryGradeStep()
        {
            if (SalaryGradeNumber != null && SalaryGradeNumber > 0 && Step != null && Step > 0)
            {
                var result = await _SalaryGradeStepManager.GetByNumberAndStepAsync(SalaryGradeNumber ?? 0, Step ?? 0);

                if (result.Status == ProcessResultStatus.Success && result.Data != null)
                {
                    if (result.Data != null)
                    {
                        SalaryGradeStep = new SalaryGradeStepModel(result.Data, SalaryGradeModel.TryCreate(result.Data.SalaryGrade));
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

            _RegionManager.RequestNavigate(MainViewModel.MainViewContentRegion, nameof(PersonalDataSheetView), parameters);
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
            var result = await _EmployeeManager.InsertAsync(Employee.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                await InsertEmployeeSalaryGradeStepAsync(result.Data);
                await InsertEmployeeWorkdayScheduleAsync(result.Data);

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
            else if (result.Status == ProcessResultStatus.Failed)
            {
                EnqueueMessage($"Failed to add new employee. {result.Message}");
            }
        }
                        
        private async Task UpdateAsync()
        {
            var result = await _EmployeeManager.UpdateAsync(Employee.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                await InsertEmployeeSalaryGradeStepAsync(result.Data);
                await InsertEmployeeWorkdayScheduleAsync(result.Data);

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

                var result = await _EmployeeSalaryGradeStepManager.InsertAsync(employeeSalaryGradeStep);

                if (result.Status == ProcessResultStatus.Failed)
                {
                    EnqueueMessage(result.Message);
                }
            }
        }

        private async Task InsertEmployeeWorkdayScheduleAsync(IEmployee employee)
        {
            if (employee != null && WorkdaySchedule != null)
            {
                var employeeWorkdaySchedule = WorkdaySchedule.GetSource() ?? new EmployeeWorkdaySchedule();
                employeeWorkdaySchedule.Employee = employee;
                var result = await _EmployeeWorkdayScheduleManager.InsertAsync(employeeWorkdaySchedule);

                if (result.Status == ProcessResultStatus.Failed)
                {
                    EnqueueMessage(result.Message);
                }
            }
        }
    }
}
