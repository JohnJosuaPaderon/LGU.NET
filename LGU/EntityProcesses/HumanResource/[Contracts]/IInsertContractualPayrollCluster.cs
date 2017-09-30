using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertContractualPayrollCluster : IProcess<IContractualPayrollCluster>
    {
        IContractualPayrollCluster PayrollCluster { get; set; }
    }
}
