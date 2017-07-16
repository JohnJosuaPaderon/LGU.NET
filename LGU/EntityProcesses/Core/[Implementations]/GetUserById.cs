﻿using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetUserById : UserProcess, IGetUserById
    {
        public GetUserById(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long UserId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", UserId);

        public IDataProcessResult<User> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter.FromReader);
        }

        public Task<IDataProcessResult<User>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync);
        }

        public Task<IDataProcessResult<User>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync, cancellationToken);
        }
    }
}
