using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class Employee : Person
    {
        public Department Department { get; set; }
        public EmployeeType Type { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public Position Position { get; set; }
        public PayrollGroup PayrollGroup { get; set; }
    }
}
