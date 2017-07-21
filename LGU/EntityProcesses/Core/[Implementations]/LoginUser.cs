﻿using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using LGU.Security;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class LoginUser : UserProcess, ILoginUser
    {
        public LoginUser(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public UserCredentials UserCredentials { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Username", SecureHash.ComputeSHA512(UserCredentials.SecureUsername))
            .AddInputParameter("@_Password", SecureHash.ComputeSHA512(UserCredentials.SecurePassword));

        public IProcessResult<User> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter);
        }

        public Task<IProcessResult<User>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter);
        }

        public Task<IProcessResult<User>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter, cancellationToken);
        }
    }
}
