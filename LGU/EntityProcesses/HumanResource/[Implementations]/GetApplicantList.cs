using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetApplicantList : ApplicantProcess, IGetApplicantList
    {
        public GetApplicantList(IConnectionStringSource connectionStringSource, IApplicantConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<IApplicant> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IApplicant>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IApplicant>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
