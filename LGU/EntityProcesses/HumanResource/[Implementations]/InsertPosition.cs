using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertPosition : PositionProcess, IInsertPosition
    {
        public InsertPosition(IConnectionStringSource connectionStringSource, IPositionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IPosition Position { get; set; }

        private SqlQueryInfo<IPosition> QueryInfo =>
            SqlQueryInfo<IPosition>.CreateProcedureQueryInfo(Position, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int32)
            .AddInputParameter("@_Description", Position.Description)
            .AddInputParameter("@_Abbreviation", Position.Abbreviation)
            .AddLogByParameter();

        private IProcessResult<IPosition> GetProcessResult(IPosition data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                Position.Id = command.Parameters.GetInt32("@_Id");
                return new ProcessResult<IPosition>(data);
            }
            else
            {
                return new ProcessResult<IPosition>(ProcessResultStatus.Failed, "Failed to insert position.");
            }
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
