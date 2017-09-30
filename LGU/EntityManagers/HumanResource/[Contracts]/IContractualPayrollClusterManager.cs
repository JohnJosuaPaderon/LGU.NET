using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IContractualPayrollClusterManager
    {
        IProcessResult<IContractualPayrollCluster> Insert(IContractualPayrollCluster payrollCluster);
        Task<IProcessResult<IContractualPayrollCluster>> InsertAsync(IContractualPayrollCluster payrollCluster);
        Task<IProcessResult<IContractualPayrollCluster>> InsertAsync(IContractualPayrollCluster payrollCluster, CancellationToken cancellationToken);
    }
}
