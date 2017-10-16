using System.Collections.Generic;

namespace LGU.Entities.HumanResource
{
    public interface IPayrollContractualDepartment : IPayrollDepartment
    {
        IEnumerable<IPayrollContractualEmployee> Employees { get; set; }
    }
}
