﻿using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetPositionList : PositionProcess, IGetPositionList
    {
        public GetPositionList(IConnectionStringSource connectionStringSource, IPositionConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<Position> Execute()
        {
            return r_SqlHelper.ExecuteReaderEnumerable(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<Position>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter);
        }

        public Task<IEnumerableProcessResult<Position>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}