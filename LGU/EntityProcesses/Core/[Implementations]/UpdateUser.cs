using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class UpdateUser : UserProcess, IUpdateUser
    {
        public UpdateUser(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public User User { get; set; }

        private SqlDataQueryInfo<User> QueryInfo =>
            SqlDataQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true);

        private IDataProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.SecureUsername?.Dispose();
                data.SecurePassword?.Dispose();
                data.SecureUsername = null;
                data.SecurePassword = null;
                return new DataProcessResult<User>(data);
            }
            else
            {
                return new DataProcessResult<User>(data, ProcessResultStatus.Failed, "Failed to update user.");
            }
        }

        public IDataProcessResult<User> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IDataProcessResult<User>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IDataProcessResult<User>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
