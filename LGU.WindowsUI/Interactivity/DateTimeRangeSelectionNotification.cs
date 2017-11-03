using LGU.Models;
using System;

namespace LGU.Interactivity
{
    public sealed class DateTimeRangeSelectionNotification : CustomNotification, IDateTimeRangeSelectionNotification
    {
        public DateTimeRangeSelectionNotification() : this("Select a Date...", new ValueRangeModel<DateTime>(new ValueRange<DateTime>(DateTime.Now)))
        {
        }

        public DateTimeRangeSelectionNotification(string header, ValueRangeModel<DateTime> dateTimeRange)
        {
            Header = header;
            DateTimeRange = dateTimeRange;
        }

        private string _Header;
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }
        
        private ValueRangeModel<DateTime> _DateTimeRange;
        public ValueRangeModel<DateTime> DateTimeRange
        {
            get { return _DateTimeRange; }
            set { SetProperty(ref _DateTimeRange, value); }
        }
    }
}
