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
            return r_SqlHelper.ExecuteReaderEnumerable(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
