using LGU.Models.HumanResource;

namespace LGU.ViewModels.HumanResource.Dialogs
{
    public sealed class AddEditCalendarEventDialogContent : DataDialogContent
    {
        private CalendarEventModel _CalendarEvent;
        public CalendarEventModel CalendarEvent
        {
            get { return _CalendarEvent; }
            set { SetProperty(ref _CalendarEvent, value); }
        }
    }
}
