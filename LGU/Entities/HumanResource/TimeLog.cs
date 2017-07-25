using System;

namespace LGU.Entities.HumanResource
{
    public class TimeLog : Entity<long>
    {
        public TimeLog(Employee employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public Employee Employee { get; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
        public TimeLogType Type { get; set; }
        public bool? State { get; set; }
    }
}
