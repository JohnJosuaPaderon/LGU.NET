using System;

namespace LGU.Entities.HumanResource
{
    public class TimeLog : Entity<long>, ITimeLog
    {
        public TimeLog(IEmployee employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public IEmployee Employee { get; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public ITimeLogType Type { get; set; }
        public bool? State { get; set; }
    }
}
