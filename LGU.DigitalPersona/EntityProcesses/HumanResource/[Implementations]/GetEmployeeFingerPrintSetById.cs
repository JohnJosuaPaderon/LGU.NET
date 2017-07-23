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
            return r_SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
