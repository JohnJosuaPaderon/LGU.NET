using System;

namespace LGU.Entities.HumanResource
{
    public interface ICalendarEvent : IEntity<long>
    {
        string Description { get; set; }
        DateTime DateOccur { get; set; }
        DateTime? DateOccurEnd { get; set; }
        bool IsHoliday { get; set; }
        bool IsNonWorking { get; set; }
        bool IsAnnual { get; set; }
    }
}
