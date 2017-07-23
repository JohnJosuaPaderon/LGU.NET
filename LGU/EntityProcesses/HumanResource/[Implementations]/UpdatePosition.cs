﻿using LGU.Data.Extensions;
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

        public Position Position { get; set; }

        private SqlQueryInfo<Position> QueryInfo =>
            SqlQueryInfo<Position>.CreateProcedureQueryInfo(Position, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", Position.Id)
            .AddInputParameter("@_Description", Position.Description)
            .AddInputParameter("@_Abbreviation", Position.Abbreviation)
            .AddLogByParameter();

        private IProcessResult<Position> GetProcessResult(Position data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Position>(data);
            }
            else
            {
                return new ProcessResult<Position>(ProcessResultStatus.Failed, "Failed to update position.");
            }
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
