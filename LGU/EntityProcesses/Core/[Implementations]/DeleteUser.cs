using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class DeleteUser : UserProcess, IDeleteUser
    {
        public DeleteUser(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public User User { get; set; }

        private SqlQueryInfo<User> QueryInfo =>
            SqlQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", User.Id)
            .AddLogByParameter();

        private IProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
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
