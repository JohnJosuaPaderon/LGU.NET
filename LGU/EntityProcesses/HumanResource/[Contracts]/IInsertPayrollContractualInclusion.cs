using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayrollContractualInclusion : IProcess<IPayrollContractualInclusion, SqlConnection, SqlTransaction>
    {
        IPayrollContractualInclusion PayrollContractualInclusion { get; set; }
    }
}
