using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeFingerPrintSetList : EmployeeFingerPrintSetProcess, IGetEmployeeFingerPrintSetList
    {
        public GetEmployeeFingerPrintSetList(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName(), GetProcessResult);

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

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
