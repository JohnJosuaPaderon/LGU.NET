﻿using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetPersonById : PersonProcess, IGetPersonById
    {
        public GetPersonById(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long PersonId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", PersonId);

        public IDataProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter.FromReader);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync, cancellationToken);
        }
    }
}
