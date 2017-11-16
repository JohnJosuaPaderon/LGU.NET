using LGU.Entities.Core;
using System.Security;

namespace LGU.Entities.HumanResource
{
    public class Employee : Person, IEmployee
    {
        public IDepartment Department { get; set; }
        public IEmployeeType Type { get; set; }
        public IEmploymentStatus EmploymentStatus { get; set; }
        public IPosition Position { get; set; }
        public IEmployee DepartmentHead { get; set; }
        public IWorkTimeSchedule WorkTimeSchedule { get; set; }
        public decimal MonthlySalary { get; set; }
        public IPayrollType PayrollType { get; set; }
        public bool IsFlexWorkSchedule { get; set; }
        public string TimeKeepingCode { get; set; }
        public string Title { get; set; }
        public SecureString SecureBankAccountNumber { get; set; }
    }
}
