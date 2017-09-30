using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertContractualPayrollCluster<TConnection, TTransaction> : IProcess<IContractualPayrollCluster>, IProcess<IContractualPayrollCluster, TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
    }
}
