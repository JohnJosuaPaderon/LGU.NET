using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class DeleteUser : CoreProcessBase, IDeleteUser
    {
        public DeleteUser(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public User User { get; set; }

        private SqlDataQueryInfo<User> QueryInfo =>
            SqlDataQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", User.Id)
            .AddLogByParameter();

        private IProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new ProcessResult<User>(data);
            }
            else
            {
                return new ProcessResult<User>(ProcessResultStatus.Failed);
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
