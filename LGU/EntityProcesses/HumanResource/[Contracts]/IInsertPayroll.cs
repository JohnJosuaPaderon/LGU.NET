using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayroll<TConnection, TTransaction> : IProcess<IPayroll>, IProcess<IPayroll, TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IPayroll Payroll { get; set; }
    }
}
