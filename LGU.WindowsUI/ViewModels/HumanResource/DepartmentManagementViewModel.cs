using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
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

        private readonly IDepartmentManager DepartmentManager;

        public DepartmentManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            RequestSearchCommand = new DelegateCommand(RequestSearch);
            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            DepartmentManager = SystemRuntime.Services.GetService<IDepartmentManager>();
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
            DepartmentEvent = EventAggregator.GetEvent<DepartmentEvent>();
        }

        private async void RequestSearch()
        {
            var result = await (string.IsNullOrWhiteSpace(SearchKey) ? DepartmentManager.GetListAsync() : DepartmentManager.SearchAsync(SearchKey));

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
            EventAggregator.GetEvent<AddDepartmentEvent>().Publish(new DepartmentModel(new Department()));
        }

        private void Edit()
        {
            EventAggregator.GetEvent<EditDepartmentEvent>().Publish(SelectedDepartment);
        }
    }
}
