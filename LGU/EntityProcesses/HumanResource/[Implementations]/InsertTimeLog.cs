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

        public ITimeLog TimeLog { get; set; }

        private SqlQueryInfo<ITimeLog> QueryInfo =>
            SqlQueryInfo<ITimeLog>.CreateProcedureQueryInfo(TimeLog, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_EmployeeId", TimeLog.Employee?.Id)
            .AddInputParameter("@_LoginDate", TimeLog.LoginDate)
            .AddInputParameter("@_LogoutDate", TimeLog.LogoutDate)
            .AddInputParameter("@_TypeId", TimeLog.Type?.Id)
            .AddLogByParameter();

        private IProcessResult<ITimeLog> GetProcessResult(ITimeLog data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<ITimeLog>(data);
            }
            else
            {
                return new ProcessResult<ITimeLog>(ProcessResultStatus.Failed, "Failed to insert time log.");
            }
        }

        public IProcessResult<ITimeLog> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ITimeLog>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ITimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
