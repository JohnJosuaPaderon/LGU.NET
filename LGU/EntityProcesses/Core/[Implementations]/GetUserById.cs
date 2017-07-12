using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LGU.Entities.Core;
using LGU.Data.RDBMS;
using System.Data.SqlClient;
using LGU.Data.Extensions;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetUserById : CoreProcessBase, IGetUserById
    {
        public GetUserById(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public long UserId { get; set; }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo("GetUserById", GetProcessResult)
                    .AddInputParameter("@_Id", UserId);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IDataProcessResult<User> Execute()
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<User>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<User>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
