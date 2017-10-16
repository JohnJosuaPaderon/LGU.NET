using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class SearchEmployee : EmployeeProcess, ISearchEmployee
    {
        private const string PARAM_SEARCH_KEY = "@_SearchKey";

        public SearchEmployee(IConnectionStringSource connectionStringSource, IEmployeeConverter converter) : base(connectionStringSource, converter)
        {
        }

        public string SearchKey { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter(PARAM_SEARCH_KEY, SearchKey);

        public IEnumerableProcessResult<IEmployee> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
