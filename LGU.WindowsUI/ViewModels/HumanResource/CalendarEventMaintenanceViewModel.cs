using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Models.HumanResource;
using LGU.Processes;
using LGU.ViewModels.HumanResource.Dialogs;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource
{
    public sealed class CalendarEventMaintenanceViewModel : ViewModelBase
    {
        public CalendarEventMaintenanceViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _CalendarEventManager = ApplicationDomain.GetService<ICalendarEventManager>();

            CalendarEvents = new ObservableCollection<CalendarEventModel>();
            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            AddEditRequest = new InteractionRequest<INotification>();
        }

        private readonly ICalendarEventManager _CalendarEventManager;

        public ObservableCollection<CalendarEventModel> CalendarEvents { get; }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand EditCommand { get; }
        public InteractionRequest<INotification> AddEditRequest { get; }

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

            var result = await _CalendarEventManager.GetListAsync();

            if (result.Status == ProcessResultStatus.Success)
            {
                if (result.DataList != null && result.DataList.Any())
                {
                    foreach (var item in result.DataList)
                    {
                        CalendarEvents.Add(new CalendarEventModel(item));
                    }
                }
                else
                {
                    EnqueueMessage("No events");
                }
            }
            else
            {
                EnqueueMessage(result.Message);
            }
        }

        private void Add()
        {
            AddEditRequest.Raise(new Notification
            {
                Title = string.Empty,
                Content = new AddEditCalendarEventDialogContent
                {
                    Header = "Add Calendar Event",
                    CalendarEvent = new CalendarEventModel(new CalendarEvent()), Mode = DialogMode.Add
                }
            }, notification =>
            {
                if (notification.Content is AddEditCalendarEventDialogContent content)
                {
                    if (content.Mode == DialogMode.Add && content.CalendarEvent != null)
                    {
                        CalendarEvents.Add(content.CalendarEvent);
                    }
                }
            });
        }

        private void Edit()
        {

            AddEditRequest.Raise(new Notification { Title = string.Empty, Content = new AddEditCalendarEventDialogContent { Header = "Edit Calendar Event", CalendarEvent = SelectedCalendarEvent, Mode = DialogMode.Edit } });
        }
    }
}
