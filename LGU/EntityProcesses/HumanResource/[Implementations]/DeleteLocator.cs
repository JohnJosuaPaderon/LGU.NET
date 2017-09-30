using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class DeleteLocator : LocatorProcess, IDeleteLocator
    {
        public DeleteLocator(IConnectionStringSource connectionStringSource, ILocatorConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ILocator Locator { get; set; }

        private SqlQueryInfo<ILocator> QueryInfo =>
            SqlQueryInfo<ILocator>.CreateProcedureQueryInfo(Locator, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("@_Id", Locator.Id)
                .AddLogByParameter();

        private IProcessResult<ILocator> GetProcessResult(ILocator Locator, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ILocator>(Locator);
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Failed to delete locator.");
            }
        }

        public IProcessResult<ILocator> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ILocator>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ILocator>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
