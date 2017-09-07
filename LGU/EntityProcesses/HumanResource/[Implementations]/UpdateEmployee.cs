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

        public IEmployee Employee { get; set; }

        private SqlQueryInfo<IEmployee> QueryInfo =>
            SqlQueryInfo<IEmployee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName(), GetProcessResult, true)
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
            .AddInputParameter("@_DepartmentHeadId", Employee.DepartmentHead?.Id)
            .AddInputParameter("@_WorkTimeScheduleId", Employee.WorkTimeSchedule?.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployee> GetProcessResult(IEmployee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployee>(data);
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<IEmployee> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
