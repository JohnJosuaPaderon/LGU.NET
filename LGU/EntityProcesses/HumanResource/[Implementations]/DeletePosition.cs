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

        public Position Position { get; set; }

        private SqlQueryInfo<Position> QueryInfo =>
            SqlQueryInfo<Position>.CreateProcedureQueryInfo(Position, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Position.Id)
            .AddLogByParameter();

        private IProcessResult<Position> GetProcessResult(Position data, SqlCommand command, int affectedRows)
        {
            return affectedRows > 0 ? new ProcessResult<Position>(data) : new ProcessResult<Position>(ProcessResultStatus.Failed, "Failed to delete position.");
        }

        public IProcessResult<Position> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Position>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Position>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
