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
    public sealed class DeleteTimeLogType : TimeLogTypeProcess, IDeleteTimeLogType
    {
        public DeleteTimeLogType(IConnectionStringSource connectionStringSource, ITimeLogTypeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public TimeLogType TimeLogType { get; set; }

        private SqlQueryInfo<TimeLogType> QueryInfo =>
            SqlQueryInfo<TimeLogType>.CreateProcedureQueryInfo(TimeLogType, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", TimeLogType.Id)
            .AddLogByParameter();

        private IProcessResult<TimeLogType> GetProcessResult(TimeLogType data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<TimeLogType>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<TimeLogType>(data, ProcessResultStatus.Failed, "Failed to delete time log type.");
            }
        }

        public IProcessResult<TimeLogType> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<TimeLogType>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<TimeLogType>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
