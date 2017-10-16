using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using Prism.Events;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource
{
    public sealed class CalendarEventMaintenanceViewModel : ViewModelBase
    {
        public CalendarEventMaintenanceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _CalendarEventManager = ApplicationDomain.GetService<ICalendarEventManager>();

            CalendarEvents = new ObservableCollection<CalendarEventModel>();
        }

        private readonly ICalendarEventManager _CalendarEventManager;

        public ObservableCollection<CalendarEventModel> CalendarEvents { get; }

        private CalendarEventModel _SelectedCalendarEvent;
        public CalendarEventModel SelectedCalendarEvent
        {
            get { return _SelectedCalendarEvent; }
            set { SetProperty(ref _SelectedCalendarEvent, value); }
        }

        protected async override void Initialize()
        {
            await TryGetCalendarEventListAsync();
        }

        private async Task TryGetCalendarEventListAsync()
        {
            if (CalendarEvents.Count <= 0)
            {
                await GetCalendarEventListAsync();
            }
        }

        private async Task GetCalendarEventListAsync()
        {
            CalendarEvents.Clear();

            
        }
    }
}
