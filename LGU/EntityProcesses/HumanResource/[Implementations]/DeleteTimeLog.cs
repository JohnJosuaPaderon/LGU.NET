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

        public ITimeLog TimeLog { get; set; }

        private SqlQueryInfo<ITimeLog> QueryInfo =>
            SqlQueryInfo<ITimeLog>.CreateProcedureQueryInfo(TimeLog, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", TimeLog.Id)
            .AddLogByParameter();

        private IProcessResult<ITimeLog> GetProcessResult(ITimeLog data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ITimeLog>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<ITimeLog>(ProcessResultStatus.Failed, "Failed to delete time log.");
            }
        }

        public IProcessResult<ITimeLog> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ITimeLog>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ITimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
