using System;
using System.Collections.Generic;
using System.Text;

namespace LGU.Entities.HumanResource
{
    public class PayrollContractual : Payroll<IPayrollContractualDepartment>, IPayrollContractual
    {
        public PayrollContractual() : base(PayrollType.Contractual, new PayrollContractualDepartmentCollection())
        {
        }
    }
}
