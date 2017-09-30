using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayrollContractualEmployee<TConnection, TTransaction> : IProcess<IPayrollContractualEmployee>, IProcess<IPayrollContractualEmployee, TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
    }
}
