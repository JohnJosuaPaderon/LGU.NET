using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public interface IPayrollContractualInclusionManager
    {
        IProcessResult<IPayrollContractualInclusion> Get(IPayrollContractual payrollContractual);
        Task<IProcessResult<IPayrollContractualInclusion>> GetAsync(IPayrollContractual payrollContractual);
        Task<IProcessResult<IPayrollContractualInclusion>> GetAsync(IPayrollContractual payrollContractual, CancellationToken cancellationToken);
        IProcessResult<IPayrollContractualInclusion> Insert(IPayrollContractualInclusion payrollContractualInclusion, SqlConnection connection, SqlTransaction transaction);
        Task<IProcessResult<IPayrollContractualInclusion>> InsertAsync(IPayrollContractualInclusion payrollContractualInclusion, SqlConnection connection, SqlTransaction transaction);
        Task<IProcessResult<IPayrollContractualInclusion>> InsertAsync(IPayrollContractualInclusion payrollContractualInclusion, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken);
    }
}
