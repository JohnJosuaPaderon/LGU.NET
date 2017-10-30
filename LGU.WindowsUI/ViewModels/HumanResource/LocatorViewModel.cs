using LGU.Entities.HumanResource;
using LGU.Events.HumanResource;
using LGU.Models.HumanResource;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace LGU.ViewModels.HumanResource
{
    public sealed class LocatorViewModel : ViewModelBase, INavigationAware
	{
        private readonly AddLocatorEvent r_AddEvent;
        private readonly EditLocatorEvent r_EditEvent;

        public LocatorViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            r_AddEvent = _EventAggregator.GetEvent<AddLocatorEvent>();
            r_EditEvent = _EventAggregator.GetEvent<EditLocatorEvent>();

            AddCommand = new DelegateCommand(Add);
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand EditCommand { get; }

        private LocatorModel _SelectedLocator;
        public LocatorModel SelectedLocator
        {
            get { return _SelectedLocator; }
            set { SetProperty(ref _SelectedLocator, value); }
        }

        private void Add()
        {
            r_AddEvent.Publish(new LocatorModel(new Locator(new Employee())));
        }

        private void Edit()
        {
            r_EditEvent.Publish(SelectedLocator);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _ChangeHeaderEvent.Publish("Locator");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
