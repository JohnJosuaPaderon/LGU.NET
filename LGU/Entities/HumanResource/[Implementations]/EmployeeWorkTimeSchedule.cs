using System;

namespace LGU.Entities.HumanResource
{
    public class EmployeeWorkTimeSchedule : Entity<long>, IEmployeeWorkTimeSchedule
    {
        public EmployeeWorkTimeSchedule(IEmployee employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public IEmployee Employee { get; }
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeEnd { get; set; }
        public DateTime? EffectivityDate { get; set; }
        public TimeSpan WorkTimeLength { get; set; }
        public bool IsEnabled { get; set; }
        public int InvocationLevel { get; set; }
    }
}
