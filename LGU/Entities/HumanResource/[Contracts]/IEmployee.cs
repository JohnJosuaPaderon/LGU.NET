using LGU.Entities.Core;
using System.Security;

namespace LGU.Entities.HumanResource
{
    public interface IEmployee : IPerson
    {
        IDepartment Department { get; set; }
        IEmployeeType Type { get; set; }
        IEmploymentStatus EmploymentStatus { get; set; }
        IPosition Position { get; set; }
        IEmployee DepartmentHead { get; set; }
        IWorkTimeSchedule WorkTimeSchedule { get; set; }
        decimal MonthlySalary { get; set; }
        IPayrollType PayrollType { get; set; }
        bool IsFlexWorkSchedule { get; set; }
        string TimeKeepingCode { get; set; }
        string Title { get; set; }
        SecureString SecureBankAccountNumber { get; set; }
    }
}
