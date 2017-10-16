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
    public sealed class GetCalendarEventById : HumanResourceProcessBaseV2, IGetCalendarEventById
    {
        public GetCalendarEventById(IConnectionStringSource connectionStringSource, ICalendarEventConverter converter, ICalendarEventParameters parameters) : base(connectionStringSource)
        {
            _Converter = converter;
            _Parameters = parameters;
        }

        private readonly ICalendarEventConverter _Converter;
        private readonly ICalendarEventParameters _Parameters;

        public long CalendarEventId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(nameof(GetCalendarEventById))
            .AddInputParameter(_Parameters.Id, CalendarEventId);

        public IProcessResult<ICalendarEvent> Execute()
        {
            _Converter.PId.Value = CalendarEventId;
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ICalendarEvent>> ExecuteAsync()
        {
            _Converter.PId.Value = CalendarEventId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ICalendarEvent>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PId.Value = CalendarEventId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
