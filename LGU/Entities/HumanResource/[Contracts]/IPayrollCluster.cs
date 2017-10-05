using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public interface IPayrollCluster<TPayrollEmployee>
        where TPayrollEmployee : IPayrollEmployee
    {
        IPayroll Payroll { get; set; }
        IEnumerable<TPayrollEmployee> Employees { get; set; }
    }
}
