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
    public sealed class InsertCalendarEvent : HumanResourceProcessBaseV2, IInsertCalendarEvent
    {
        private const string MESSAGE_FAILED = "Failed to insert calendar event.";

        public InsertCalendarEvent(IConnectionStringSource connectionStringSource, ICalendarEventParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly ICalendarEventParameters _Parameters;

        public ICalendarEvent CalendarEvent { get; set; }

        private SqlQueryInfo<ICalendarEvent> QueryInfo =>
            SqlQueryInfo<ICalendarEvent>.CreateProcedureQueryInfo(CalendarEvent, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
            .AddInputParameter(_Parameters.Description, CalendarEvent.Description)
            .AddInputParameter(_Parameters.DateOccur, CalendarEvent.DateOccur)
            .AddInputParameter(_Parameters.DateOccurEnd, CalendarEvent.DateOccurEnd)
            .AddInputParameter(_Parameters.IsHoliday, CalendarEvent.IsHoliday)
            .AddInputParameter(_Parameters.IsNonWorking, CalendarEvent.IsNonWorking)
            .AddInputParameter(_Parameters.IsAnnual, CalendarEvent.IsAnnual)
            .AddLogByParameter();

        private IProcessResult<ICalendarEvent> GetProcessResult(ICalendarEvent data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64(_Parameters.Id);
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
