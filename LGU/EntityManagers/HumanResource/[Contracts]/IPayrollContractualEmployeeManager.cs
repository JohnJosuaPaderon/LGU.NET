using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollContractualEmployeeManager<TConnection, TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee payrollContractualEmployee);
        IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee payrollContractualEmployee, TConnection connection, TTransaction transaction);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, TConnection connection, TTransaction transaction);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, CancellationToken cancellationToken);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, TConnection connection, TTransaction transaction, CancellationToken cancellationToken);
        IEnumerableProcessResult<IPayrollContractualEmployee> GenerateList(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IPayrollContractualEmployee>> GenerateListAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IPayrollContractualEmployee>> GenerateListAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}
