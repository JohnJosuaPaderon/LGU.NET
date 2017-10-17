using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteCalendarEvent : HumanResourceProcessBaseV2, IDeleteCalendarEvent
    {
        private const string MESSAGE_FAILED = "Failed to delete calendar event.";
        private const string PARAM_ID = "@_Id";

        public DeleteCalendarEvent(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public ICalendarEvent CalendarEvent { get; set; }

        private SqlQueryInfo<ICalendarEvent> QueryInfo =>
            SqlQueryInfo<ICalendarEvent>.CreateProcedureQueryInfo(CalendarEvent, GetQualifiedDbObjectName(), GetProcessResult)
            .AddInputParameter(PARAM_ID, CalendarEvent.Id)
            .AddLogByParameter();

        private IProcessResult<ICalendarEvent> GetProcessResult(ICalendarEvent data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ICalendarEvent>(data);
            }
            else
            {
                return new ProcessResult<ICalendarEvent>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<ICalendarEvent> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ICalendarEvent>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ICalendarEvent>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
