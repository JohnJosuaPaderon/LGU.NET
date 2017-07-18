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
    public sealed class DeleteTimeLog : TimeLogProcess, IDeleteTimeLog
    {
        public DeleteTimeLog(IConnectionStringSource connectionStringSource, ITimeLogConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public TimeLog TimeLog { get; set; }

        private SqlQueryInfo<TimeLog> QueryInfo =>
            SqlQueryInfo<TimeLog>.CreateProcedureQueryInfo(TimeLog, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", TimeLog.Id)
            .AddLogByParameter();

        private IProcessResult<TimeLog> GetProcessResult(TimeLog data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<TimeLog>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<TimeLog>(ProcessResultStatus.Failed, "Failed to delete time log.");
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
