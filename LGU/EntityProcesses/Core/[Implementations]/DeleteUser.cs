using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
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

        private SqlDataQueryInfo<User> QueryInfo
        {
            get
            {
                return SqlDataQueryInfo<User>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName("DeleteUser"), GetProcessResult, true)
                    .AddInputParameter("@_Id", User.Id)
                    .AddLogByParameter();
            }
        }

        private IDataProcessResult<User> GetProcessResult(User data, SqlCommand command, int affectedRows)
        {
            if (affectedRows == 1)
            {
                return new DataProcessResult<User>(data);
            }
            else
            {
                return new DataProcessResult<User>(ProcessResultStatus.Failed);
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
