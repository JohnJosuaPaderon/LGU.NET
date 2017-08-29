using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditEmployeeDialogViewModel : DialogViewModelBase
    {
        private readonly IEmployeeManager r_EmployeeManager;
        private readonly IDepartmentManager r_DepartmentManager;
        private readonly AddEmployeeEvent r_AddEmployeeEvent;
        private readonly EditEmployeeEvent r_EditEmployeeEvent;

        public AddEditEmployeeDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_EmployeeManager = SystemRuntime.GetService<IEmployeeManager>();
            r_DepartmentManager = SystemRuntime.GetService<IDepartmentManager>();

            SaveCommand = new DelegateCommand(Save);
            r_AddEmployeeEvent = r_EventAggregator.GetEvent<AddEmployeeEvent>();
            r_EditEmployeeEvent = r_EventAggregator.GetEvent<EditEmployeeEvent>();
            Initialize();
        }

        public DelegateCommand SaveCommand { get; }
        public ObservableCollection<IDepartment> Departments { get; } = new ObservableCollection<IDepartment>();

        private EmployeeModel _Employee;
        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }

        private bool _Multiple;
        public bool Multiple
        {
            get { return _Multiple; }
            set { SetProperty(ref _Multiple, value); }
        }

        public async override void Initialize()
        {
            base.Initialize();
            r_AddEmployeeEvent.Subscribe(e => SetData(e, "Add new Employee", DialogMode.Add));
            r_EditEmployeeEvent.Subscribe(e => SetData(e, "Edit Employee", DialogMode.Edit));
            await GetDepartmentListAsync();
        }

        private async Task GetDepartmentListAsync()
        {
            var result = await r_DepartmentManager.GetListAsync();

            if (result.Status == ProcessResultStatus.Success && result.DataList != null)
            {
                Departments.AddRange(result.DataList);
            }
            else
            {
                ShowErrorMessage(result.Message);
            }
        }

        private void SetData(EmployeeModel employee, string headerTitle, DialogMode mode)
        {
            Employee = employee;
            HeaderTitle = headerTitle;
            Mode = mode;
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
            var result = await r_EmployeeManager.InsertAsync(Employee.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                if (Multiple)
                {
                    Employee = new EmployeeModel(new Employee());
                }
                else
                {
                    DialogHelper.CloseDialog();
                }

                ShowInfoMessage("Employee has been added successfully.");
            }
            else if (result.Status == ProcessResultStatus.Failed)
            {
                ShowErrorMessage($"Failed to add new employee.\n{result.Message}");
            }
        }
                        
        private async Task UpdateAsync()
        {
            var result = await r_EmployeeManager.UpdateAsync(Employee.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                DialogHelper.CloseDialog();
                ShowInfoMessage("Employee details has been updated successfully.");
            }
            else if (result.Status == ProcessResultStatus.Failed)
            {
                ShowErrorMessage($"Failed to update employee.\n{result.Message}");
            }
        }
    }
}
