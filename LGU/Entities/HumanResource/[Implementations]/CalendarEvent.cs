using System;

namespace LGU.Entities.HumanResource
{
    public class CalendarEvent : Entity<long>, ICalendarEvent
    {
        public string Description { get; set; }
        public DateTime DateOccur { get; set; }
        public DateTime? DateOccurEnd { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsNonWorking { get; set; }
        public bool IsAnnual { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
