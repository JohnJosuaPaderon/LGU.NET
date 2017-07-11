using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public class EmployeeFingerPrintEnrollmentViewModel : ViewModelBase
    {
        private readonly IEmployeeManager EmployeeManager;
        private readonly IEmployeeFingerPrintSetManager EmployeeFingerPrintSetManager;
        private readonly EmployeeEvent EmployeeEvent;
        private readonly AddEmployeeEvent AddEmployeeEvent;
        private readonly EditEmployeeEvent EditEmployeeEvent;
        private readonly ManageEmployeeFingerPrintSetEvent ManageEmployeeFingerPrintSetEvent;

        public EmployeeFingerPrintEnrollmentViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            EmployeeManager = SystemRuntime.Services.GetService<IEmployeeManager>();
            EmployeeFingerPrintSetManager = SystemRuntime.Services.GetService<IEmployeeFingerPrintSetManager>();

            EmployeeEvent = EventAggregator.GetEvent<EmployeeEvent>();
            AddEmployeeEvent = EventAggregator.GetEvent<AddEmployeeEvent>();
            EditEmployeeEvent = EventAggregator.GetEvent<EditEmployeeEvent>();
            ManageEmployeeFingerPrintSetEvent = EventAggregator.GetEvent<ManageEmployeeFingerPrintSetEvent>();
            SearchCommand = new DelegateCommand(Search);
            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            ManageFingerPrintCommand = new DelegateCommand(ManageFingerPrint);
        }

        public ObservableCollection<EmployeeModel> Employees { get; } = new ObservableCollection<EmployeeModel>();
        public DelegateCommand AddCommand { get; }
        public DelegateCommand EditCommand { get; }
        public DelegateCommand SearchCommand { get; }
        public DelegateCommand ManageFingerPrintCommand { get; }

        private EmployeeModel _SelectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { SetProperty(ref _SelectedEmployee, value, () =>
            {
                EmployeeEvent.Publish(value);
            }); }
        }

        private string _SearchKey;
        public string SearchKey
        {
            get { return _SearchKey; }
            set { SetProperty(ref _SearchKey, value); }
        }

        private async void Search()
        {
            Employees.Clear();

            var result = await (string.IsNullOrWhiteSpace(SearchKey) ? EmployeeManager.GetListAsync() : EmployeeManager.SearchAsync(SearchKey));

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var item in result.DataList)
                    {
                        Employees.Add(new EmployeeModel(item));
                    }
                }
            }
        }

        private void Add()
        {
            AddEmployeeEvent.Publish(new EmployeeModel(new Employee()));
        }

        private void Edit()
        {
            EditEmployeeEvent.Publish(SelectedEmployee);
        }

        private async void ManageFingerPrint()
        {
            var source = SelectedEmployee.GetSource();
            var result = await EmployeeFingerPrintSetManager.GetByIdAsync(source);

            if (result.Status == ProcessResultStatus.Success && result.Data != null)
            {
                ManageEmployeeFingerPrintSetEvent.Publish(new EmployeeFingerPrintSetModel(result.Data));
            }
            else
            {
                ManageEmployeeFingerPrintSetEvent.Publish(new EmployeeFingerPrintSetModel(new EmployeeFingerPrintSet(source)));
            }
        }

        public override void Initialize()
        {
            
        }
    }
}
