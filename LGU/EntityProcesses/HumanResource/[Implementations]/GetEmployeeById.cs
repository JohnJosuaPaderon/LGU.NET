using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.HumanResource;
using LGU.EntityProcessHelpers.HumanResource;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeById : HumanResourceProcessBase, IGetEmployeeById
    {
        public GetEmployeeById(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public long EmployeeId { get; set; }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetEmployeeById"), GetProcessResult)
                    .AddInputParameter("@_Id", EmployeeId);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IDataProcessResult<Employee> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, EmployeeProcessHelper.FromReader);
        }

        public Task<IDataProcessResult<Employee>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, EmployeeProcessHelper.FromReaderAsync);
        }

        public Task<IDataProcessResult<Employee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, EmployeeProcessHelper.FromReaderAsync, cancellationToken);
        }
    }
}
