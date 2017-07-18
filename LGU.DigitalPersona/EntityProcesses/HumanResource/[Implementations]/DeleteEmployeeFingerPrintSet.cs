using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteEmployeeFingerPrintSet : HumanResourceProcessBase, IDeleteEmployeeFingerPrintSet
    {
        public DeleteEmployeeFingerPrintSet(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public EmployeeFingerPrintSet FingerPrintSet { get; set; }

        private SqlDataQueryInfo<EmployeeFingerPrintSet> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<EmployeeFingerPrintSet>.CreateProcedureQueryInfo(FingerPrintSet, GetQualifiedDbObjectName("DeleteEmployeeFingerPrintSet"), GetProcessResult, true)
                    .AddInputParameter("@_Id", FingerPrintSet.Employee?.Id)
                    .AddLogByParameter();
            }
        }

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
