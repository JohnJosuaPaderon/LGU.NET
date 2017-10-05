using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public class PayrollCluster<TPayrollEmployee> : IPayrollCluster<TPayrollEmployee>
        where TPayrollEmployee : IPayrollEmployee
    {
        public IPayroll Payroll { get; set; }
        public IEnumerable<TPayrollEmployee> Employees { get; set; }
    }
}
