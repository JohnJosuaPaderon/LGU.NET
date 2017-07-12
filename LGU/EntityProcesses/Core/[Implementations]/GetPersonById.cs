using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityProcessHelpers.Core;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetPersonById : CoreProcessBase, IGetPersonById
    {
        public GetPersonById(IConnectionStringSource connectionStringSource) : base(connectionStringSource)
        {
        }

        public long PersonId { get; set; }

        private SqlQueryInfo QueryInfo
        {
            get
            {
                return SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName("GetPersonById"), GetProcessResult)
                    .AddInputParameter("@_Id", PersonId);
            }
        }

        private IProcessResult GetProcessResult(SqlCommand command, int affectedRows)
        {
            return new ProcessResult(ProcessResultStatus.Success);
        }

        public IDataProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, PersonProcessHelper.FromReader);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, PersonProcessHelper.FromReaderAsync);
        }

        public Task<IDataProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, PersonProcessHelper.FromReaderAsync, cancellationToken);
        }
    }
}
