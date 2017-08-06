using System;

namespace LGU.Entities.HumanResource
{
    public class Locator : Entity<long>
    {
        public Employee Requestor { get; }
        public DateTime OfficeOutTime { get; set; }
        public DateTime? ExpectedReturnTime { get; set; }
    }
}
