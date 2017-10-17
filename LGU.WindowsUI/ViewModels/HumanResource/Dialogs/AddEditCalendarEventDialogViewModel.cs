using LGU.Entities.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Threading.Tasks;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditCalendarEventDialogViewModel : PopupViewModelBase
    {
        public AddEditCalendarEventDialogViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _CalendarEventManager = ApplicationDomain.GetService<ICalendarEventManager>();

            SaveCommand = new DelegateCommand(Save);
            SelectDateCommand = new DelegateCommand<string>(SelectDate);
            ClearDateCommand = new DelegateCommand<string>(ClearDate);
            CancelCommand = new DelegateCommand(Cancel);
            DateTimeSelectionRequest = new InteractionRequest<INotification>();
        }

        private readonly ICalendarEventManager _CalendarEventManager;

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand<string> SelectDateCommand { get; }
        public DelegateCommand<string> ClearDateCommand { get; }
        public DelegateCommand CancelCommand { get; }
        public InteractionRequest<INotification> DateTimeSelectionRequest { get; }
        
        private void Cancel()
        {
            if (Content is AddEditCalendarEventDialogContent content)
            {
                if (content.Mode == DialogMode.Add)
                {
                    content.CalendarEvent = null;
                }
            }
            Close();
        }

        private async void Save()
        {
            var content = (Content as AddEditCalendarEventDialogContent);

            if (content != null)
            {
                var calendarEvent = content.CalendarEvent;
                var mode = content.Mode;

                if (calendarEvent != null)
                {
                    switch (mode)
                    {
                        case DialogMode.NotSet:
                            _NewMessageEvent.Publish("Nothing dto do.");
                            break;
                        case DialogMode.Add:
                            await AddAsync(calendarEvent.GetSource());
                            break;
                        case DialogMode.Edit:
                            await UpdateAsync(calendarEvent.GetSource());
                            break;
                        case DialogMode.Delete:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void GetDate(DateTime initialValue, Action<DateTime> callback, string header = "Select a Date...")
        {
            DateTimeSelectionRequest.Raise(new Notification { Title = string.Empty, Content = new DateTimeSelectionContent { Header = header, SelectedDate = initialValue } }, arg => callback((arg.Content as DateTimeSelectionContent).SelectedDate));
        }

        private void SelectDate(string propertyName)
        {
            if (Content is AddEditCalendarEventDialogContent content)
            {
                switch (propertyName)
                {
                    case nameof(CalendarEvent.DateOccur):
                        GetDate(content.CalendarEvent.DateOccur, arg => content.CalendarEvent.DateOccur = arg);
                        break;
                    case nameof(CalendarEvent.DateOccurEnd):
                        GetDate(content.CalendarEvent.DateOccurEnd ?? DateTime.Now, arg => content.CalendarEvent.DateOccurEnd = arg);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClearDate(string propertyName)
        {
            if (Content is AddEditCalendarEventDialogContent content)
            {
                switch (propertyName)
                {
                    case nameof(CalendarEvent.DateOccur):
                        content.CalendarEvent.DateOccur = DateTime.Now;
                        break;
                    case nameof(CalendarEvent.DateOccurEnd):
                        content.CalendarEvent.DateOccurEnd = null;
                        break;
                    default:
                        break;
                }
            }
        }

        private async Task AddAsync(ICalendarEvent calendarEvent)
        {
            var result = await _CalendarEventManager.InsertAsync(calendarEvent);

            if (result.Status == ProcessResultStatus.Success)
            {
                _NewMessageEvent.Publish("Calendar event successfully added.");
                Close();
            }
            else
            {
                _NewMessageEvent.Publish(result.Message);
            }
        }

        private async Task UpdateAsync(ICalendarEvent calendarEvent)
        {
            var result = await _CalendarEventManager.UpdateAsync(calendarEvent);

            if (result.Status == ProcessResultStatus.Success)
            {
                _NewMessageEvent.Publish("Calendar event successfully updated.");
                Close();
            }
            else
            {
                _NewMessageEvent.Publish(result.Message);
            }
        }
    }
}
