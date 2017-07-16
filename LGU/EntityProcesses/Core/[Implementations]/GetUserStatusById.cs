﻿using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetUserStatusById : UserStatusProcess, IGetUserStatusById
    {
        public GetUserStatusById(IConnectionStringSource connectionStringSource, IUserStatusConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public short UserStatusId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", UserStatusId);

        public IDataProcessResult<UserStatus> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter.FromReader);
        }

        public Task<IDataProcessResult<UserStatus>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync);
        }

        public Task<IDataProcessResult<UserStatus>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter.FromReaderAsync, cancellationToken);
        }
    }
}