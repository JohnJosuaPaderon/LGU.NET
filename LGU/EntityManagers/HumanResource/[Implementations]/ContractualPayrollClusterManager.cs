using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ContractualPayrollClusterManager : IContractualPayrollClusterManager
    {
        private const string MESSAGE_INVALID = "Invalid contractual payroll cluster.";

        public ContractualPayrollClusterManager(IInsertContractualPayrollCluster insert)
        {
            _Insert = insert;
        }

        private readonly IInsertContractualPayrollCluster _Insert;

        public IProcessResult<IContractualPayrollCluster> Insert(IContractualPayrollCluster payrollCluster)
        {
            if (payrollCluster != null)
            {
                _Insert.PayrollCluster = payrollCluster;
                return _Insert.Execute();
            }
            else
            {
                return new ProcessResult<IContractualPayrollCluster>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public async Task<IProcessResult<IContractualPayrollCluster>> InsertAsync(IContractualPayrollCluster payrollCluster)
        {
            if (payrollCluster != null)
            {
                _Insert.PayrollCluster = payrollCluster;
                return await _Insert.ExecuteAsync();
            }
            else
            {
                return new ProcessResult<IContractualPayrollCluster>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }

        public async Task<IProcessResult<IContractualPayrollCluster>> InsertAsync(IContractualPayrollCluster payrollCluster, CancellationToken cancellationToken)
        {
            if (payrollCluster != null)
            {
                _Insert.PayrollCluster = payrollCluster;
                return await _Insert.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new ProcessResult<IContractualPayrollCluster>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            }
        }
    }
}
