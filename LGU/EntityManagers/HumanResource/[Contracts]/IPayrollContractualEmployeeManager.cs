using LGU.Entities.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollContractualEmployeeManager
    {
        IProcessResult<IPayrollContractualEmployee> Insert(IPayrollContractualEmployee payrollContractualEmployee, SqlConnection connection, SqlTransaction transaction);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, SqlConnection connection, SqlTransaction transaction);
        Task<IProcessResult<IPayrollContractualEmployee>> InsertAsync(IPayrollContractualEmployee payrollContractualEmployee, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken);
        IEnumerableProcessResult<IPayrollContractualEmployee> GenerateList(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IPayrollContractualEmployee>> GenerateListAsync(ValueRange<DateTime> cutOff);
        Task<IEnumerableProcessResult<IPayrollContractualEmployee>> GenerateListAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken);
    }
}
