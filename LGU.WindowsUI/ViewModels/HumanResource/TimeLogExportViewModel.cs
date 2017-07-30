using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class TimeLogExportViewModel : ViewModelBase
    {
        public TimeLogExportViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }
    }
}
