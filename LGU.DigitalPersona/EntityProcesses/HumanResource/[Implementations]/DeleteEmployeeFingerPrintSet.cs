using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
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

        private IDataProcessResult<EmployeeFingerPrintSet> GetProcessResult(EmployeeFingerPrintSet data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(data);
            }
            else
            {
                return new DataProcessResult<EmployeeFingerPrintSet>(ProcessResultStatus.Failed);
            }
        }

        public IDataProcessResult<EmployeeFingerPrintSet> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<EmployeeFingerPrintSet>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<EmployeeFingerPrintSet>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
