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
        public GetEmployeeFingerPrintSetList(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName(), GetProcessResult);

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IEnumerableProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, Converter);
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter);
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter, cancellationToken);
        }
    }
}
