using LGU.Data.RDBMS;
using LGU.Data.Utilities;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses
{
    public sealed class GetSystemDate : IGetSystemDate
    {
        private readonly SqlHelper SqlHelper;

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return new SqlQueryInfo()
                {
                    CommandText = "SELECT dbo.GetSystemDate();",
                    GetProcessResult = GetProcessResult
                };
            }
        }

        private IDataProcessResult<DateTime> Converter(object arg)
        {
            var result = DbValueConverter.ToNullableDateTime(arg);

            return new DataProcessResult<DateTime>(result ?? default(DateTime), result == null ? ProcessResultStatus.Failed : ProcessResultStatus.Success);
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            throw new NotImplementedException();
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
