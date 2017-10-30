using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class PreviewEmployeeViewModel : ViewModelBase
    {
        private EmployeeModel _Employee;

        public PreviewEmployeeViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _EventAggregator.GetEvent<EmployeeEvent>().Subscribe(pl => Employee = pl);
        }

        public EmployeeModel Employee
        {
            get { return _Employee; }
            set { SetProperty(ref _Employee, value); }
        }
    }
}
