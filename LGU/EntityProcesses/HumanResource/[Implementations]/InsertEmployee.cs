using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertEmployee : HumanResourceProcessBase, IInsertEmployee
    {
        private const string MESSAGE_FAILED = "Failed to insert employee.";

        public InsertEmployee(IConnectionStringSource connectionStringSource, IEmployeeParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly IEmployeeParameters _Parameters;

        public IEmployee Employee { get; set; }

        private SqlQueryInfo<IEmployee> QueryInfo =>
            SqlQueryInfo<IEmployee>.CreateProcedureQueryInfo(Employee, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
            .AddInputParameter(_Parameters.FirstName, Employee.FirstName)
            .AddInputParameter(_Parameters.MiddleName, Employee.MiddleName)
            .AddInputParameter(_Parameters.LastName, Employee.LastName)
            .AddInputParameter(_Parameters.NameExtension, Employee.NameExtension)
            .AddInputParameter(_Parameters.BirthDate, Employee.BirthDate)
            .AddInputParameter(_Parameters.GenderId, Employee.Gender?.Id)
            .AddInputParameter(_Parameters.Deceased, Employee.Deceased)
            .AddInputParameter(_Parameters.DepartmentId, Employee.Department?.Id)
            .AddInputParameter(_Parameters.TypeId, Employee.Type?.Id)
            .AddInputParameter(_Parameters.EmploymentStatusId, Employee.EmploymentStatus?.Id)
            .AddInputParameter(_Parameters.PositionId, Employee.Position?.Id)
            .AddInputParameter(_Parameters.DepartmentHeadId, Employee.DepartmentHead?.Id)
            .AddInputParameter(_Parameters.WorkTimeScheduleId, Employee.WorkTimeSchedule?.Id)
            .AddInputParameter(_Parameters.MonthlySalary, Employee.MonthlySalary)
            .AddInputParameter(_Parameters.IsFlexWorkSchedule, Employee.IsFlexWorkSchedule)
            .AddLogByParameter();

        private IProcessResult<IEmployee> GetProcessResult(IEmployee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64(_Parameters.Id);
                return new ProcessResult<IEmployee>(data);
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IEmployee> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
