using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetWorkTimeScheduleById : WorkTimeScheduleProcess, IGetWorkTimeScheduleById
    {
        public GetWorkTimeScheduleById(IConnectionStringSource connectionStringSource, IWorkTimeScheduleConverter converter) : base(connectionStringSource, converter)
        {
        }

        public int WorkTimeScheduleId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", WorkTimeScheduleId);

        public IProcessResult<IWorkTimeSchedule> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IWorkTimeSchedule>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IWorkTimeSchedule>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
