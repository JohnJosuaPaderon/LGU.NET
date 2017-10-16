using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetActualTimeLogListByEmployeeCutOff : TimeLogProcess, IGetActualTimeLogListByEmployeeCutOff
    {
        public GetActualTimeLogListByEmployeeCutOff(IConnectionStringSource connectionStringSource, ITimeLogConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IEmployee Employee { get; set; }
        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_EmployeeId", Employee.Id)
            .AddInputParameter("@_CutOffBegin", CutOff.Begin)
            .AddInputParameter("@_CutOffEnd", CutOff.End);

        public IEnumerableProcessResult<ITimeLog> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<ITimeLog>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<ITimeLog>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
