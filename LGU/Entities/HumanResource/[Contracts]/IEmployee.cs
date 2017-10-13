using LGU.Entities.Core;

namespace LGU.Entities.HumanResource
{
    public interface IEmployee : IPerson
    {
        IDepartment Department { get; set; }
        IEmployeeType Type { get; set; }
        IEmploymentStatus EmploymentStatus { get; set; }
        IPosition Position { get; set; }
        IDepartmentHead DepartmentHead { get; set; }
        IWorkTimeSchedule WorkTimeSchedule { get; set; }
        decimal MonthlySalary { get; set; }
        IPayrollType PayrollType { get; set; }
        bool IsFlexWorkSchedule { get; set; }
    }
}
