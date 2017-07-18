using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LGU.EntityConverters.Core;
using LGU.Processes;
using LGU.Data.Rdbms;

namespace LGU.EntityProcesses.Core
{
    public sealed class IsUsernameExists : UserProcess, IIsUsernameExists
    {
        public IsUsernameExists(IConnectionStringSource connectionStringSource, IUserConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public SecureString SecureUsername { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo

        public IProcessResult<bool> Execute()
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<bool>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<bool>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
