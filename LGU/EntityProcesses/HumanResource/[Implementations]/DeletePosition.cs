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
    public sealed class DeletePosition : PositionProcess, IDeletePosition
    {
        public DeletePosition(IConnectionStringSource connectionStringSource, IPositionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IPosition Position { get; set; }

        private SqlQueryInfo<IPosition> QueryInfo =>
            SqlQueryInfo<IPosition>.CreateProcedureQueryInfo(Position, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Position.Id)
            .AddLogByParameter();

        private IProcessResult<IPosition> GetProcessResult(IPosition data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<IPosition>(data) : new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Failed to delete position.");
        }

        public IProcessResult<IPosition> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IPosition>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPosition>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
