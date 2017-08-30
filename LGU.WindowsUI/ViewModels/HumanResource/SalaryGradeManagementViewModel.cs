using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class SalaryGradeManagementViewModel : ViewModelBase
    {
        public SalaryGradeManagementViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_ChangeHeaderEvent.Publish("Salary Grade Management");
        }
    }
}
