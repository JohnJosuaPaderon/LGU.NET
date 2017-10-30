using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;

namespace LGU.ViewModels.HumanResource
{
    public class EmployeeFingerPrintEnrollmentViewModel : ViewModelBase, INavigationAware
    {
        private readonly IEmployeeManager _EmployeeManager;
        private readonly IEmployeeFingerPrintSetManager _EmployeeFingerPrintSetManager;
        private readonly EmployeeEvent _EmployeeEvent;
        private readonly AddEmployeeEvent _AddEmployeeEvent;
        private readonly EditEmployeeEvent _EditEmployeeEvent;
        private readonly ManageEmployeeFingerPrintSetEvent _ManageEmployeeFingerPrintSetEvent;

        public EmployeeFingerPrintEnrollmentViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _EmployeeManager = ApplicationDomain.GetService<IEmployeeManager>();
            _EmployeeFingerPrintSetManager = ApplicationDomain.GetService<IEmployeeFingerPrintSetManager>();

            _EmployeeEvent = _EventAggregator.GetEvent<EmployeeEvent>();
            _AddEmployeeEvent = _EventAggregator.GetEvent<AddEmployeeEvent>();
            _EditEmployeeEvent = _EventAggregator.GetEvent<EditEmployeeEvent>();
            _ManageEmployeeFingerPrintSetEvent = _EventAggregator.GetEvent<ManageEmployeeFingerPrintSetEvent>();
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
                _EmployeeEvent.Publish(value);
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

            var result = await (string.IsNullOrWhiteSpace(SearchKey) ? _EmployeeManager.GetListAsync() : _EmployeeManager.SearchAsync(SearchKey));

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    _NewMessageEvent.Publish($"Found {result.DataList.Count().ToString("#,##0")} employee(s).");

                    foreach (var item in result.DataList)
                    {
                        Employees.Add(new EmployeeModel(item));
                    }
                }
                else
                {
                    _NewMessageEvent.Publish("No employee matched.");
                }
            }
            else
            {
                _NewMessageEvent.Publish($"There's an error on searching employees: {result.Message}");
            }
        }

        private void Add()
        {
            _AddEmployeeEvent.Publish(new EmployeeModel(new Employee()));
        }

        private void Edit()
        {
            _EditEmployeeEvent.Publish(SelectedEmployee);
        }

        private async void ManageFingerPrint()
        {
            var source = SelectedEmployee.GetSource();
            var result = await _EmployeeFingerPrintSetManager.GetByIdAsync(source);

            if (result.Status == ProcessResultStatus.Success && result.Data != null)
            {
                _ManageEmployeeFingerPrintSetEvent.Publish(new EmployeeFingerPrintSetModel(result.Data));
            }
            else
            {
                _ManageEmployeeFingerPrintSetEvent.Publish(new EmployeeFingerPrintSetModel(new EmployeeFingerPrintSet(source)));
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _ChangeHeaderEvent.Publish("Employees");
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
