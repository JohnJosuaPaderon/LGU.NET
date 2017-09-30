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

        public IUser User { get; set; }

        private SqlQueryInfo<IUser> QueryInfo =>
            SqlQueryInfo<IUser>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_OwnerId", User.Owner?.Id)
            .AddInputParameter("@_Username", SecureHash.ComputeSHA512(User.SecureUsername))
            .AddInputParameter("@_Password", SecureHash.ComputeSHA512(User.SecurePassword))
            .AddInputParameter("@_StatusId", User.Status?.Id)
            .AddInputParameter("@_TypeId", User.Type?.Id)
            .AddInputParameter("@_DisplayName", User.DisplayName)
            .AddLogByParameter();

        private IProcessResult<IUser> GetProcessResult(IUser data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                data.SecureUsername.Dispose();
                data.SecurePassword.Dispose();
                data.SecureUsername = null;
                data.SecurePassword = null;
                return new ProcessResult<IUser>(data);
            }
            else
            {
                return new ProcessResult<IUser>(data, ProcessResultStatus.Failed, "Failed to insert user.");
            }
        }

        public IProcessResult<IUser> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IUser>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IUser>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
