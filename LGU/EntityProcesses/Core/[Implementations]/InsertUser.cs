using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using LGU.Security;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class InsertUser : UserProcess, IInsertUser
    {
        public InsertUser(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public User User { get; set; }

        private SqlQueryInfo<User> QueryInfo =>
            SqlQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_OwnerId", User.Owner?.Id)
            .AddInputParameter("@_Username", SecureHash.ComputeSHA512(User.SecureUsername))
            .AddInputParameter("@_Password", SecureHash.ComputeSHA512(User.SecurePassword))
            .AddInputParameter("@_StatusId", User.Status?.Id)
            .AddInputParameter("@_TypeId", User.Type?.Id)
            .AddInputParameter("@_DisplayName", User.DisplayName)
            .AddLogByParameter();

        private IProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                data.SecureUsername.Dispose();
                data.SecurePassword.Dispose();
                data.SecureUsername = null;
                data.SecurePassword = null;
                return new ProcessResult<User>(data);
            }
            else
            {
                return new ProcessResult<User>(data, ProcessResultStatus.Failed, "Failed to insert user.");
            }
        }

        public IProcessResult<User> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<User>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<User>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
