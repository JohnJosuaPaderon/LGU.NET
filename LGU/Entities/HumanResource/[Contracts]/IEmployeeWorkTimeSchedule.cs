using System;

namespace LGU.Entities.HumanResource
{
    public interface IEmployeeWorkTimeSchedule : IEntity<long>
    {
        IEmployee Employee { get; }
        DateTime WorkTimeStart { get; set; }
        DateTime WorkTimeEnd { get; set; }
        DateTime? EffectivityDate { get; set; }
        TimeSpan WorkTimeLength { get; set; }
        bool IsEnabled { get; set; }
        int InvocationLevel { get; set; }
    }
}
