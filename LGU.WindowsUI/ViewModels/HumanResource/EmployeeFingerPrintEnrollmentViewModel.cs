using LGU.Entities.HumanResource;
using LGU.Events;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class EmployeeFingerPrintEnrollmentViewModel : ViewModelBase
    {
        public EmployeeFingerPrintEnrollmentViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }

        public override void Load()
        {
            EventAggregator.GetEvent<EmployeeEvent>().Publish(new EventData<EmployeeModel>
            {
                Payload = new EmployeeModel(new Employee
                {
                    FirstName = "JOHN JOSUA"
                }),
                TargetViewModel = nameof(PreviewEmployeeViewModel)
            });
        }
    }
}
