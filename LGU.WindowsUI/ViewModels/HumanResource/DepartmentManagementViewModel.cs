using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Microsoft.Extensions.DependencyInjection;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows;

namespace LGU.ViewModels.HumanResource
{
    public sealed class DepartmentManagementViewModel : ViewModelBase
    {

        private readonly IDepartmentManager r_DepartmentManager;

        public DepartmentManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            RequestSearchCommand = new DelegateCommand(RequestSearch);
            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            r_DepartmentManager = SystemRuntime.Services.GetService<IDepartmentManager>();
        }

        public ObservableCollection<DepartmentModel> Departments { get; } = new ObservableCollection<DepartmentModel>();
        public DelegateCommand RequestSearchCommand { get; }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand EditCommand { get; }
        private DepartmentEvent DepartmentEvent { get; set; }

        private string _SearchKey;
        public string SearchKey
        {
            get { return _SearchKey; }
            set
            {
                SetProperty(ref _SearchKey, value);
            }
        }

        private DepartmentModel _SelectedDepartment;
        public DepartmentModel SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set { SetProperty(ref _SelectedDepartment, value, () => DepartmentEvent.Publish(value)); }
        }

        public override void Initialize()
        {
            base.Initialize();
            DepartmentEvent = r_EventAggregator.GetEvent<DepartmentEvent>();
        }

        private async void RequestSearch()
        {
            var result = await (string.IsNullOrWhiteSpace(SearchKey) ? r_DepartmentManager.GetListAsync() : r_DepartmentManager.SearchAsync(SearchKey));

            if (result.Status == ProcessResultStatus.Success && result.DataList != null)
            {
                Departments.Clear();

                foreach (var item in result.DataList)
                {
                    Departments.Add(new DepartmentModel(item));
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void Add()
        {
            r_EventAggregator.GetEvent<AddDepartmentEvent>().Publish(new DepartmentModel(new Department()));
        }

        private void Edit()
        {
            r_EventAggregator.GetEvent<EditDepartmentEvent>().Publish(SelectedDepartment);
        }
    }
}
