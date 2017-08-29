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

        public IEmployeeFingerPrintSet FingerPrintSet { get; set; }

        private SqlQueryInfo<IEmployeeFingerPrintSet> QueryInfo =>
            SqlQueryInfo<IEmployeeFingerPrintSet>.CreateProcedureQueryInfo(FingerPrintSet, GetQualifiedDbObjectName("DeleteEmployeeFingerPrintSet"), GetProcessResult, true)
            .AddInputParameter("@_Id", FingerPrintSet.Employee?.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployeeFingerPrintSet> GetProcessResult(IEmployeeFingerPrintSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IProcessResult<IEmployeeFingerPrintSet> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeFingerPrintSet>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
