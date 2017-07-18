using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using LGU.Security;
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
            SqlDataQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", "@_Id")
            .AddInputParameter("@_OwnerId", User.Owner?.Id)
            .AddInputParameter("@_Username", SecureHash.ComputeSHA512(User.SecureUsername))
            .AddInputParameter("@_Password", SecureHash.ComputeSHA512(User.SecurePassword))
            .AddInputParameter("@_StatusId", User.Status?.Id)
            .AddInputParameter("@_TypeId", User.Type?.Id)
            .AddInputParameter("@_DisplayName", User.DisplayName)
            .AddLogByParameter();

        private IProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.SecureUsername?.Dispose();
                data.SecurePassword?.Dispose();
                data.SecureUsername = null;
                data.SecurePassword = null;
                return new ProcessResult<User>(data);
            }
            else
            {
                return new ProcessResult<User>(data, ProcessResultStatus.Failed, "Failed to update user.");
            }
        }

        public IProcessResult<User> Execute()
        {
            return SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<User>> ExecuteAsync()
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<User>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
