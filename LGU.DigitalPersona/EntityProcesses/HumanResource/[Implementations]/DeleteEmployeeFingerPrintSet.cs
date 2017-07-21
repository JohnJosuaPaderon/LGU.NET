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
    public sealed class DeleteEmployeeFingerPrintSet : EmployeeFingerPrintSetProcess, IDeleteEmployeeFingerPrintSet
    {
        public DeleteEmployeeFingerPrintSet(IConnectionStringSource connectionStringSource, IEmployeeFingerPrintSetConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public EmployeeFingerPrintSet FingerPrintSet { get; set; }

        private SqlQueryInfo<EmployeeFingerPrintSet> QueryInfo =>
            SqlQueryInfo<EmployeeFingerPrintSet>.CreateProcedureQueryInfo(FingerPrintSet, GetQualifiedDbObjectName("DeleteEmployeeFingerPrintSet"), GetProcessResult, true)
            .AddInputParameter("@_Id", FingerPrintSet.Employee?.Id)
            .AddLogByParameter();

        private IProcessResult<EmployeeFingerPrintSet> GetProcessResult(EmployeeFingerPrintSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<EmployeeFingerPrintSet>(data);
            }
            else
            {
                return new ProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
