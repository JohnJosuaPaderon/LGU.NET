using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayrollContractualEmployee : IProcess<IPayrollContractualEmployee, SqlConnection, SqlTransaction>
    {
        IPayrollContractualEmployee PayrollContractualEmployee { get; set; }
    }
}
