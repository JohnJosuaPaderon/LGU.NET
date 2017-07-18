using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateEmployee : HumanResourceProcessBase, IUpdateEmployee
    {
        public UpdateEmployee(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public Employee Employee { get; set; }

        private SqlQueryInfo<Employee> QueryInfo =>
            SqlQueryInfo<Employee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Employee.Id)
            .AddInputParameter("@_FirstName", Employee.FirstName)
            .AddInputParameter("@_MiddleName", Employee.MiddleName)
            .AddInputParameter("@_LastName", Employee.LastName)
            .AddInputParameter("@_NameExtension", Employee.NameExtension)
            .AddInputParameter("@_BirthDate", Employee.BirthDate)
            .AddInputParameter("@_GenderId", Employee.Gender?.Id)
            .AddInputParameter("@_Deceased", Employee.Deceased)
            .AddInputParameter("@_DepartmentId", Employee.Department?.Id)
            .AddLogByParameter();

        private IProcessResult<Employee> GetProcessResult(Employee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Employee>(data);
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<Employee> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
