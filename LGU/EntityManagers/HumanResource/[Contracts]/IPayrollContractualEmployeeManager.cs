using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollContractualEmployeeManager<TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee employee);
        IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee employee, TConnection connection, TTransaction transaction);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee employee);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee employee, TConnection connection, TTransaction transaction);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee employee, CancellationToken cancellationToken);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee employee, TConnection connection, TTransaction transaction, CancellationToken cancellationToken);
    }
}
