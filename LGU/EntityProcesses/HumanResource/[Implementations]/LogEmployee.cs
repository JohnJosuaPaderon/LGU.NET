using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.EntityManagers.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class LogEmployee : TimeLogProcess, ILogEmployee
    {
        private readonly ITimeLogTypeManager TimeLogTypeManager;

        public LogEmployee(IConnectionStringSource connectionStringSource, ITimeLogConverter<SqlDataReader> converter, ITimeLogTypeManager timeLogTypeManager) : base(connectionStringSource, converter)
        {
            TimeLogTypeManager = timeLogTypeManager;
        }

        public Employee Employee { get; set; }

        private SqlDataQueryInfo<TimeLog> QueryInfo =>
            SqlDataQueryInfo<TimeLog>.CreateProcedureQueryInfo(new TimeLog(Employee), GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_EmployeeId", Employee.Id)
            .AddOutputParameter("@_LoginDate", DbType.DateTime)
            .AddOutputParameter("@_LogoutDate", DbType.DateTime)
            .AddOutputParameter("@_TypeId", DbType.Int16)
            .AddLogByParameter();

        private IProcessResult<TimeLog> GetProcessResult(TimeLog data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                var typeResult = TimeLogTypeManager.GetById(command.Parameters.GetInt16("@_TypeId"));

                data.Id = command.Parameters.GetInt64("@_Id");
                data.LoginDate = command.Parameters.GetNullableDateTime("@_LoginDate");
                data.LogoutDate = command.Parameters.GetNullableDateTime("@_LogoutDate");
                data.Type = typeResult.Data;

                return new ProcessResult<TimeLog>(data);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Failed to log employee.");
            }
        }

        public IProcessResult<TimeLog> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<TimeLog>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<TimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
