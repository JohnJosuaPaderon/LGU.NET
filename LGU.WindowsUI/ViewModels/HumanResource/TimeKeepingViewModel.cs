using LGU.Events;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class TimeKeepingViewModel : ViewModelBase
    {
        public TimeKeepingViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }

        public override void Load()
        {
            EventAggregator.GetEvent<TitleEvent>().Publish("Time-Keeping");
        }
    }
}
