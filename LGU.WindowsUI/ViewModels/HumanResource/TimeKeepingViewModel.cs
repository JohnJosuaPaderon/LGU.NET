using LGU.Events;
using LGU.Views.HumanResource;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public class TimeKeepingViewModel : BindableBase
    {
        private readonly IRegionManager RegionManager;
        private readonly IEventAggregator EventAggregator;

        public TimeKeepingViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
        }

        public void Load()
        {
            EventAggregator.GetEvent<TitleEvent>().Publish("Time-Keeping");
            RegionManager.RequestNavigate("SampleRegion", nameof(SampleView));
        }
    }
}
