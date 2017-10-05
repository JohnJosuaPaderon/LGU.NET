using LGU.Utilities;
using System;

namespace LGU.Entities.HumanResource
{
    public sealed class WorkTimeSchedule : Entity<int>, IWorkTimeSchedule
    {
        public string Description { get; set; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeEnd { get; set; }
        public TimeSpan? BreakTime { get; set; }
        public int WorkingMonthDays { get; set; }
        public int WorkingMinutes
        {
            get
            {
                return (int)DateTimeUtilities.GetTotalDayMinuteDiff(WorkTimeEnd, WorkTimeStart) - BreakTime?.Minutes ?? 0;
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
