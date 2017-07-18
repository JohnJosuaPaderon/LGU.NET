using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public class InsertTimeLog : TimeLogProcess, IInsertTimeLog
    {
        public InsertTimeLog(IConnectionStringSource connectionStringSource, ITimeLogConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public TimeLog TimeLog { get; set; }

        private SqlQueryInfo<TimeLog> QueryInfo =>
            SqlQueryInfo<TimeLog>.CreateProcedureQueryInfo(TimeLog, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_EmployeeId", TimeLog.Employee?.Id)
            .AddInputParameter("@_LoginDate", TimeLog.LoginDate)
            .AddInputParameter("@_LogoutDate", TimeLog.LogoutDate)
            .AddInputParameter("@_TypeId", TimeLog.Type?.Id)
            .AddLogByParameter();

        private IProcessResult<TimeLog> GetProcessResult(TimeLog data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<TimeLog>(data);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Failed to insert time log.");
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
