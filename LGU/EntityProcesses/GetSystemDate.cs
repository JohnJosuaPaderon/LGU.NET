using LGU.Data.Rdbms;
using LGU.Processes;
using LGU.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses
{
    public sealed class GetSystemDate : IGetSystemDate
    {
        private readonly SqlHelper r_SqlHelper;

        private SqlQueryInfo QueryInfo =>
            new SqlQueryInfo()
            {
                CommandText = "SELECT dbo.GetSystemDate();"
            };

        public GetSystemDate(IConnectionStringSource connectionStringSource)
        {
            r_SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource["Core"]));
        }

        public IProcessResult<DateTime> Execute()
        {
            return r_SqlHelper.ExecuteScalar(QueryInfo, DbValueConverter.ToDateTime);
        }

        public Task<IProcessResult<DateTime>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteScalarAsync(QueryInfo, DbValueConverter.ToDateTime);
        }

        public Task<IProcessResult<DateTime>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteScalarAsync(QueryInfo, DbValueConverter.ToDateTime, cancellationToken);
        }
    }
}
