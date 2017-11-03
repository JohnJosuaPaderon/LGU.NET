using LGU.Models;
using System;

namespace LGU.Interactivity
{
    public interface IDateTimeRangeSelectionNotification : ICustomNotification
    {
        string Header { get; set; }
        ValueRangeModel<DateTime> DateTimeRange { get; set; }
    }
}
