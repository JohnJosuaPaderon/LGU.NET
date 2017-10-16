using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetCalendarEventList : HumanResourceProcessBaseV2, IGetCalendarEventList
    {
        public GetCalendarEventList(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        private readonly ICalendarEventConverter _Converter;
        
        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<ICalendarEvent> Execute()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<ICalendarEvent>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableProcessResult<ICalendarEvent>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
