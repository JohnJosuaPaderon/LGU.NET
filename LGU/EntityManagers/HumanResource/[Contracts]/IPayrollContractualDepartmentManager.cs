using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollContractualDepartmentManager
    {
        IEnumerableProcessResult<IPayrollContractualDepartment> GenerateList(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IPayrollContractualDepartment>> GenerateListAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IPayrollContractualDepartment>> GenerateListAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}
