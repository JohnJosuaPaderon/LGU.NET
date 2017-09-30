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
    public sealed class UpdatePosition : PositionProcess, IUpdatePosition
    {
        public UpdatePosition(IConnectionStringSource connectionStringSource, IPositionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IPosition Position { get; set; }

        private SqlQueryInfo<IPosition> QueryInfo =>
            SqlQueryInfo<IPosition>.CreateProcedureQueryInfo(Position, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Position.Id)
            .AddInputParameter("@_Description", Position.Description)
            .AddInputParameter("@_Abbreviation", Position.Abbreviation)
            .AddLogByParameter();

        private IProcessResult<IPosition> GetProcessResult(IPosition data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IPosition>(data);
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Failed to update position.");
            }
        }

        public IProcessResult<IPosition> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IPosition>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPosition>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
