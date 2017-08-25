using System;

namespace LGU.Entities.HumanResource
{
    public class Locator : Entity<long>
    {
        public Locator(Employee requestor)
        {
            Requestor = requestor ?? throw new ArgumentNullException(nameof(requestor));
        }

        public Employee Requestor { get; }
        public DateTime Date { get; set; }
        public DateTime OfficeOutTime { get; set; }
        public DateTime? ExpectedReturnTime { get; set; }
        public LocatorLeaveType LeaveType { get; set; }
        public string Purpose { get; set; }
        public string DepartmentHead { get; set; }
    }
}
