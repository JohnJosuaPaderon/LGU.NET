using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class MaintenanceViewModel : ViewModelBase
    {
        private const string HEADER = "Maintenance";

        public MaintenanceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }

        protected override void Initialize()
        {
            _HeaderEvent.Publish(HEADER);
        }
    }
}
