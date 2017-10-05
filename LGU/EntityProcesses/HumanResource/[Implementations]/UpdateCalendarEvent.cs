using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class UpdateCalendarEvent : HumanResourceProcessBaseV2, IUpdateCalendarEvent
    {
        private const string MESSAGE_FAILED = "Failed to update calendar event.";
        private const string PARAM_ID = "@_Id";
        private const string PARAM_DESCRIPTION = "@_Description";
        private const string PARAM_DATE_OCCUR = "@_DateOccur";
        private const string PARAM_DATE_OCCUR_END = "@_DateOccurEnd";
        private const string PARAM_IS_HOLIDAY = "@_IsHoliday";
        private const string PARAM_IS_NON_WORKING = "@_IsNonWorking";
        private const string PARAM_IS_ANNUAL = "@_IsAnnual";

        public UpdateCalendarEvent(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public ICalendarEvent CalendarEvent { get; set; }

        private SqlQueryInfo<ICalendarEvent> QueryInfo =>
           SqlQueryInfo<ICalendarEvent>.CreateProcedureQueryInfo(CalendarEvent, nameof(InsertCalendarEvent), GetProcessResult, true)
           .AddInputParameter(PARAM_ID, CalendarEvent.Id)
           .AddInputParameter(PARAM_DESCRIPTION, CalendarEvent.Description)
           .AddInputParameter(PARAM_DATE_OCCUR, CalendarEvent.DateOccur)
           .AddInputParameter(PARAM_DATE_OCCUR_END, CalendarEvent.DateOccurEnd)
           .AddInputParameter(PARAM_IS_HOLIDAY, CalendarEvent.IsHoliday)
           .AddInputParameter(PARAM_IS_NON_WORKING, CalendarEvent.IsNonWorking)
           .AddInputParameter(PARAM_IS_ANNUAL, CalendarEvent.IsAnnual);

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
