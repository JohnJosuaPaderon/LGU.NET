using LGU.Data.Extensions;
using LGU.Data.RDBMS;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class SearchPerson : PersonProcess, ISearchPerson
    {
        public SearchPerson(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public string SearchKey { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_SearchKey", SearchKey);

        public IEnumerableProcessResult<Person> Execute()
        {
            return SqlHelper.ExecuteReaderEnumerable(QueryInfo, Converter.EnumerableFromReader);
        }

        public Task<IEnumerableProcessResult<Person>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync);
        }

        public Task<IEnumerableProcessResult<Person>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, Converter.EnumerableFromReaderAsync, cancellationToken);
        }
    }
}
