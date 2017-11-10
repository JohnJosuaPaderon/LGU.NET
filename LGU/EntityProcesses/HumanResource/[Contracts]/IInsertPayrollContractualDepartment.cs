using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IInsertPayrollContractualDepartment : IProcess<IPayrollContractualDepartment, SqlConnection, SqlTransaction>
    {
        IPayrollContractualDepartment PayrollContractualDepartment { get; set; }
    }
}
