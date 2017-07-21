using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class ApplicationMainViewModel : NavigationalViewModelBase
    {
        public static string RegionName => "ApplicationMainViewContentRegion";

        public ApplicationMainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator, RegionName)
        {
        }
    }
}
