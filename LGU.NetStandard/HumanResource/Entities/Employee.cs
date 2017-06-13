using LGU.Core.Entities;

namespace LGU.HumanResource.Entities
{
    public class Employee : Person
    {
        public EmployeePosition Position { get; set; }
        public EmploymentStatus? EmploymentStatus { get; set; }
        public decimal BasicPay { get; set; }
        public decimal DailyRate { get; set; }
    }
}
