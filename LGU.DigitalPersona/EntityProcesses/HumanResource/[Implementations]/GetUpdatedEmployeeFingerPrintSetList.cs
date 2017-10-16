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
    public sealed class GetUpdatedEmployeeFingerPrintSetList : EmployeeFingerPrintSetProcess, IGetUpdatedEmployeeFingerPrintSetList
    {
        public GetUpdatedEmployeeFingerPrintSetList(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter converter) : base(connectionStringSource, converter)
        {
        }

        public DateTime LogDate { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_LogDate", LogDate);

        public IEnumerableProcessResult<IEmployeeFingerPrintSet> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
