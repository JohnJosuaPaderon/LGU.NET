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

        public IUser User { get; set; }

        private SqlQueryInfo<IUser> QueryInfo =>
            SqlQueryInfo<IUser>.CreateProcedureQueryInfo(User, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", User.Id)
            .AddLogByParameter();

        private IProcessResult<IUser> GetProcessResult(IUser data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IUser>(data);
            }
            else
            {
                return new ProcessResult<IUser>(ProcessResultStatus.Failed);
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
