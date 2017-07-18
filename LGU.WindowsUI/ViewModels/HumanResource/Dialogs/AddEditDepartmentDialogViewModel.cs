using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public class AddEditDepartmentDialogViewModel : DialogViewModelBase
	{
        private readonly AddDepartmentEvent AddDepartmentEvent;
        private readonly EditDepartmentEvent EditDepartmentEvent;
        private readonly IDepartmentManager DepartmentManager;

        public AddEditDepartmentDialogViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            DepartmentManager = SystemRuntime.Services.GetService<IDepartmentManager>();
            SaveCommand = new DelegateCommand(Save);
            AddDepartmentEvent = EventAggregator.GetEvent<AddDepartmentEvent>();
            EditDepartmentEvent = EventAggregator.GetEvent<EditDepartmentEvent>();
            Initialize();
        }

        public DelegateCommand SaveCommand { get; }

        private DepartmentModel _Department;
        public DepartmentModel Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }

        private bool _Multiple;
        public bool Multiple
        {
            get { return _Multiple; }
            set { SetProperty(ref _Multiple, value); }
        }

        public override void Initialize()
        {
            base.Initialize();
            AddDepartmentEvent.Subscribe(d => SetData(d, "Add new Department", DialogMode.Add));
            EditDepartmentEvent.Subscribe(d => SetData(d, "Edit Department", DialogMode.Edit));
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
            var result = await DepartmentManager.InsertAsync(Department.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                if (Multiple)
                {
                    Department = new DepartmentModel(new Department());
                }
                else
                {
                    DialogHelper.CloseDialog();
                }

                ShowInfoMessage("Department has been added successfully.");
            }
            else if(result.Status == ProcessResultStatus.Failed)
            {
                ShowErrorMessage($"Failed to add new department.\n{result.Message}");
            }
        }

        private async Task UpdateAsync()
        {
            var result = await DepartmentManager.UpdateAsync(Department.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                DialogHelper.CloseDialog();
                ShowInfoMessage("Department details has been updated successfully.");
            }
            else if (result.Status == ProcessResultStatus.Failed)
            {
                ShowErrorMessage($"Failed to update department.\n{result.Message}");
            }
        }

        private void SetData(DepartmentModel department, string headerTitle, DialogMode mode)
        {
            Department = department;
            HeaderTitle = headerTitle;
            Mode = mode;
        }
    }
}
