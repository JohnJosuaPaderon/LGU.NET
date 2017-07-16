using LGU.Data.RDBMS;
using LGU.Data.Utilities;
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

        private IDataProcessResult<DateTime> Converter(object arg)
        {
            var result = DbValueConverter.ToNullableDateTime(arg);

            return new DataProcessResult<DateTime>(result ?? default(DateTime), result == null ? ProcessResultStatus.Failed : ProcessResultStatus.Success);
        }

        public GetSystemDate(IConnectionStringSource connectionStringSource)
        {
            SqlHelper = new SqlHelper(new SqlConnectionEstablisher(connectionStringSource["Core"]));
        }

        public IDataProcessResult<DateTime> Execute()
        {
            return SqlHelper.ExecuteScalar(QueryInfo, Converter);
        }

        public Task<IDataProcessResult<DateTime>> ExecuteAsync()
        {
            return SqlHelper.ExecuteScalarAsync(QueryInfo, Converter);
        }

        public Task<IDataProcessResult<DateTime>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteScalarAsync(QueryInfo, Converter, cancellationToken);
        }
    }
}
