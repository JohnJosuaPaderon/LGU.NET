using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.EntityConverters.Core;
using LGU.Processes;
using LGU.Security;
using LGU.Utilities;
using System.Data.SqlClient;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class IsUsernameExists : UserProcess, IIsUsernameExists
    {
        public IsUsernameExists(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public SecureString SecureUsername { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateFunctionQueryInfo(GetQualifiedDbObjectName(), "@_Username")
            .AddInputParameter("@_Username",SecureHash.ComputeSHA512(SecureStringConverter.Convert(SecureUsername)));

        public IProcessResult<bool> Execute()
        {
            return SqlHelper.ExecuteScalar(QueryInfo, DbValueConverter.ToBoolean);
        }

        public Task<IProcessResult<bool>> ExecuteAsync()
        {
            return SqlHelper.ExecuteScalarAsync(QueryInfo, DbValueConverter.ToBoolean);
        }

        public Task<IProcessResult<bool>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteScalarAsync(QueryInfo, DbValueConverter.ToBoolean, cancellationToken);
        }
    }
}
