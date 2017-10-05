using System;

namespace LGU.Entities.HumanResource
{
    public interface IWorkTimeSchedule : IEntity<int>
    {
        string Description { get; set; }
        DateTime WorkTimeStart { get; set; }
        DateTime WorkTimeEnd { get; set; }
        TimeSpan? BreakTime { get; set; }
        int WorkingMonthDays { get; set; }
        int WorkingMinutes { get; }
    }
}
