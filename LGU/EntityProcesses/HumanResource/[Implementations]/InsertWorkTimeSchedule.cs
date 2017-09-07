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
    public sealed class InsertWorkTimeSchedule : WorkTimeScheduleProcess, IInsertWorkTimeSchedule
    {
        public InsertWorkTimeSchedule(IConnectionStringSource connectionStringSource, IWorkTimeScheduleConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IWorkTimeSchedule WorkTimeSchedule { get; set; }

        private SqlQueryInfo<IWorkTimeSchedule> QueryInfo =>
            SqlQueryInfo<IWorkTimeSchedule>.CreateProcedureQueryInfo(WorkTimeSchedule, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int32)
            .AddInputParameter("@_WorkTimeStart", WorkTimeSchedule.WorkTimeStart)
            .AddInputParameter("@_WorkTimeEnd", WorkTimeSchedule.WorkTImeEnd)
            .AddLogByParameter();

        private IProcessResult<IWorkTimeSchedule> GetProcessResult(IWorkTimeSchedule data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<IWorkTimeSchedule>(WorkTimeSchedule);
            }
            else
            {
                return new ProcessResult<IWorkTimeSchedule>(ProcessResultStatus.Failed, "Failed to insert work-time schedule.");
            }
        }

        public IProcessResult<IWorkTimeSchedule> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IWorkTimeSchedule>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IWorkTimeSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
