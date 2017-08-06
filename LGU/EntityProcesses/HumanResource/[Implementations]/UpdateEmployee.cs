using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateEmployee : EmployeeProcess, IUpdateEmployee
    {
        public UpdateEmployee(IConnectionStringSource connectionStringSource, IEmployeeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
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
            .AddInputParameter("@_TypeId", Employee.Type?.Id)
            .AddInputParameter("@_EmploymentStatusId", Employee.EmploymentStatus?.Id)
            .AddInputParameter("@_PositionId", Employee.Position?.Id)
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
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
