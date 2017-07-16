using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
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

        private SqlDataQueryInfo<User> QueryInfo =>
            SqlDataQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_OwnerId", User.Owner?.Id)
            .AddInputParameter("@_Username", SecureHash.ComputeSHA512(User.SecureUsername))
            .AddInputParameter("@_Password", SecureHash.ComputeSHA512(User.SecurePassword))
            .AddInputParameter("@_StatusId", User.Status?.Id)
            .AddInputParameter("@_TypeId", User.Type?.Id)
            .AddInputParameter("@_DisplayName", User.DisplayName)
            .AddLogByParameter();

        private IDataProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                data.SecureUsername.Dispose();
                data.SecurePassword.Dispose();
                data.SecureUsername = null;
                data.SecurePassword = null;
                return new DataProcessResult<User>(data);
            }
            else
            {
                return new DataProcessResult<User>(data, ProcessResultStatus.Failed, "Failed to insert user.");
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
