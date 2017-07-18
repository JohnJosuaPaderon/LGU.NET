using LGU.Data.RDBMS;
using LGU.Data.Utilities;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses
{
    public sealed class GetSystemDate : IGetSystemDate
    {
        private readonly SqlHelper SqlHelper;

        private SqlQueryInfo QueryInfo =>
            new SqlQueryInfo()
            {
                CommandText = "SELECT dbo.GetSystemDate();"
            };

        private IProcessResult<DateTime> Converter(object arg)
        {
            var result = DbValueConverter.ToNullableDateTime(arg);

            return new ProcessResult<DateTime>(result ?? default(DateTime), result == null ? ProcessResultStatus.Failed : ProcessResultStatus.Success);
        }

        public GetSystemDate(IConnectionStringSource connectionStringSource)
        {
            SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource["Core"]));
        }

        public IProcessResult<DateTime> Execute()
        {
            return SqlHelper.ExecuteScalar(QueryInfo, Converter);
        }

        public Task<IProcessResult<DateTime>> ExecuteAsync()
        {
            return SqlHelper.ExecuteScalarAsync(QueryInfo, Converter);
        }

        public Task<IProcessResult<DateTime>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteScalarAsync(QueryInfo, Converter, cancellationToken);
        }
    }
}
