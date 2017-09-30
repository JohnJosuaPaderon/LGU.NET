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

        public IDepartmentHead DepartmentHead { get; set; }

        private SqlQueryInfo<IDepartmentHead> QueryInfo =>
            SqlQueryInfo<IDepartmentHead>.CreateProcedureQueryInfo(DepartmentHead, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("Id", DepartmentHead.Id)
                .AddLogByParameter();

        private IProcessResult<IDepartmentHead> GetProcessResult(IDepartmentHead DepartmentHead, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IDepartmentHead>(DepartmentHead);
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Failed to delete department head.");
            }
        }

        public IProcessResult<IDepartmentHead> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
