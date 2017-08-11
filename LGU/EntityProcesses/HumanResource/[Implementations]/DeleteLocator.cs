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

        private SqlQueryInfo<Locator> QueryInfo =>
            SqlQueryInfo<Locator>.CreateProcedureQueryInfo(Locator, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("@_Id", Locator.Id)
                .AddLogByParameter();

        private IProcessResult<Locator> GetProcessResult(Locator Locator, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<Locator>(Locator);
            }
            else
            {
                return new ProcessResult<Locator>(ProcessResultStatus.Failed, "Failed to delete locator.");
            }
        }

        public Locator Locator { get; set; }

        public IProcessResult<Locator> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<Locator>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<Locator>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
