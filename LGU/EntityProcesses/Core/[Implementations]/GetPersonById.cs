using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetPersonById : PersonProcess, IGetPersonById
    {
        public GetPersonById(IConnectionStringSource connectionStringSource, IPersonConverter converter) : base(connectionStringSource, converter)
        {
        }

        public long PersonId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", PersonId);

        public IProcessResult<IPerson> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
