using LGU.Interactivity;
using Prism.Events;

namespace LGU.ViewModels
{
    public class DateTimeRangeSelectionViewModel : PopupViewModelBase<IDateTimeRangeSelectionNotification>
    {
        public DateTimeRangeSelectionViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}
