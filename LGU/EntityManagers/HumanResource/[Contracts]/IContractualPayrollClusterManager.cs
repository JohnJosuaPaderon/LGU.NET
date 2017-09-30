using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IContractualPayrollClusterManager
    {
        IProcessResult<IContractualPayrollCluster> InsertPayroll(IContractualPayrollCluster payrollCluster);
        Task<IProcessResult<IContractualPayrollCluster>> InsertPayrollAsync(IContractualPayrollCluster payrollCluster);
        Task<IProcessResult<IContractualPayrollCluster>> InsertPayrollAsync(IContractualPayrollCluster payrollCluster, CancellationToken cancellationToken);
    }
}
