using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class SearchDepartment : DepartmentProcess, ISearchDepartment
    {
        public SearchDepartment(IConnectionStringSource connectionStringSource, IDepartmentConverter converter) : base(connectionStringSource, converter)
        {
        }

        public string SearchKey { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_SearchKey", SearchKey);

        public IEnumerableProcessResult<IDepartment> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IDepartment>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IDepartment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
