using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayrollContractualDepartment<TConnection, TTransaction> : IProcess<IPayrollContractualDepartment>, IProcess<IPayrollContractualDepartment, TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IPayrollContractualDepartment PayrollContractualDepartment { get; set; }
    }
}
