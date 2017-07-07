using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Diagnostics;

namespace LGU.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        protected readonly IRegionManager RegionManager;
        protected readonly IEventAggregator EventAggregator;

        public ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
        }

        public virtual void Load()
        {
            Debug.WriteLine("ViewModel has been Loaded.");
        }
    }
}
