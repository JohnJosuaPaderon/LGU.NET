using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public class PayrollContractualDepartment : PayrollDepartment, IPayrollContractualDepartment
    {
        public IEnumerable<IPayrollContractualEmployee> Employees { get; set; }
    }
}
