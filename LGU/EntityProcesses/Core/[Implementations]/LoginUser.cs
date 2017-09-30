using LGU.Data.Extensions;
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

        public IUserCredentials UserCredentials { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Username", SecureHash.ComputeSHA512(UserCredentials.SecureUsername))
            .AddInputParameter("@_Password", SecureHash.ComputeSHA512(UserCredentials.SecurePassword));

        public IProcessResult<IUser> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IUser>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IUser>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
