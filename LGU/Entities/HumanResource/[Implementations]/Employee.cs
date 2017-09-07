using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public class Employee : Person, IEmployee
    {
        public IDepartment Department { get; set; }
        public IEmployeeType Type { get; set; }
        public IEmploymentStatus EmploymentStatus { get; set; }
        public IPosition Position { get; set; }
        public IDepartmentHead DepartmentHead { get; set; }
        public IWorkTimeSchedule WorkTimeSchedule { get; set; }
    }
}
