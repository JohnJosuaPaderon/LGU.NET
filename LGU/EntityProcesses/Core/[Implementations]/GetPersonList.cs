﻿using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetPersonList : PersonProcess, IGetPersonList
    {
        public GetPersonList(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableDataProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, Converter.EnumerableFromReader);
        }

        public Task<IEnumerableDataProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableDataProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}
