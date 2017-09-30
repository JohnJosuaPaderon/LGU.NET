using System;

namespace LGU.Entities.HumanResource
{
    public interface IWorkTimeSchedule : IEntity<int>
    {
        string Description { get; set; }
        DateTime WorkTimeStart { get; set; }
        DateTime WorkTImeEnd { get; set; }
        TimeSpan? BreakTime { get; set; }
    }
}
