using LGU.Entities.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace LGU.ViewModels.HumanResource
{
    public class EmployeeFingerPrintEnrollmentViewModel : ViewModelBase
    {
        public EmployeeFingerPrintEnrollmentViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            EmployeeEvent = EventAggregator.GetEvent<EmployeeEvent>();
            SearchCommand = new DelegateCommand(Search);
        }

        private readonly EmployeeEvent EmployeeEvent;

        public ObservableCollection<EmployeeModel> Employees { get; } = new ObservableCollection<EmployeeModel>();
        public DelegateCommand SearchCommand { get; }

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

        private void Search()
        {
            Employees.Clear();

            for (int i = 0; i < SearchKey.Length; i++)
            {
                Employees.Add(new EmployeeModel(new Employee
                {
                    FirstName = $"JOHN JOSUA ({i})",
                    MiddleName = $"ROBLES ({i})",
                    LastName = $"PADERON ({i})",
                    Department = new Department()
                    {
                        Description = $"MANAGEMENT INFORMATION SYSTEMS OFFICE ({i})"
                    }
                }));
            }
        }

        public override void Load()
        {
            
        }
    }
}
