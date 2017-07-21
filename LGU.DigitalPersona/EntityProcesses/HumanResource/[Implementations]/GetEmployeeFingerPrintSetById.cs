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
    public sealed class GetEmployeeFingerPrintSetById : EmployeeFingerPrintSetProcess, IGetEmployeeFingerPrintSetById
    {
        public GetEmployeeFingerPrintSetById(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public Employee Employee { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetEmployeeFingerPrintSetById"), GetProcessResult)
            .AddInputParameter("@_Id", Employee?.Id);

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter, cancellationToken);
        }
    }
}
