using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateTimeLogType : TimeLogTypeProcess, IUpdateTimeLogType
    {
        public UpdateTimeLogType(IConnectionStringSource connectionStringSource, ITimeLogTypeConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public TimeLogType TimeLogType { get; set; }

        private SqlDataQueryInfo<TimeLogType> QueryInfo =>
            SqlDataQueryInfo<TimeLogType>.CreateProcedureQueryInfo(TimeLogType, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", TimeLogType.Id)
            .AddInputParameter("@_Description", TimeLogType.Description)
            .AddInputParameter("@_WorkTimeLength", TimeLogType.WorkTimeLength.Ticks)
            .AddInputParameter("@_BreakTimeLength", TimeLogType.BreakTimeLength?.Ticks)
            .AddLogByParameter();

        private IDataProcessResult<TimeLogType> GetProcessResult(TimeLogType data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new DataProcessResult<TimeLogType>(data);
            }
            else
            {
                return new DataProcessResult<TimeLogType>(ProcessResultStatus.Failed, "Failed to update time log type.");
            }
        }

        public IDataProcessResult<TimeLogType> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<TimeLogType>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<TimeLogType>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
