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
    public sealed class DeleteDepartmentHead : DepartmentHeadProcess, IDeleteDepartmentHead
    {
        public DeleteDepartmentHead(IConnectionStringSource connectionStringSource, IDepartmentHeadConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo<DepartmentHead> QueryInfo =>
            SqlQueryInfo<DepartmentHead>.CreateProcedureQueryInfo(DepartmentHead, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("Id", DepartmentHead.Id)
                .AddLogByParameter();

        private IProcessResult<DepartmentHead> GetProcessResult(DepartmentHead DepartmentHead, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<DepartmentHead>(DepartmentHead);
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Failed to delete department head.");
            }
        }

        public DepartmentHead DepartmentHead { get; set; }

        public IProcessResult<DepartmentHead> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<DepartmentHead>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<DepartmentHead>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
