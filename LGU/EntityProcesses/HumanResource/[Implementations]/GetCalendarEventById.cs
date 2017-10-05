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
        private const string PARAM_ID = "@_Id";

        public GetCalendarEventById(IConnectionStringSource connectionStringSource, ICalendarEventConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            _Converter = converter;
        }

        private readonly ICalendarEventConverter<SqlDataReader> _Converter;

        public long CalendarEventId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(nameof(GetCalendarEventById))
            .AddInputParameter(PARAM_ID, CalendarEventId);

        public IProcessResult<ICalendarEvent> Execute()
        {
            _Converter.Prop_Id.Value = CalendarEventId;
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ICalendarEvent>> ExecuteAsync()
        {
            _Converter.Prop_Id.Value = CalendarEventId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ICalendarEvent>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.Prop_Id.Value = CalendarEventId;
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
