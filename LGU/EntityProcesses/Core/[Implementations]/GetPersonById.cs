using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.Core;
using LGU.EntityConverters.Core;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.Core
{
    public sealed class GetPersonById : PersonProcess, IGetPersonById
    {
        public GetPersonById(IConnectionStringSource connectionStringSource, IPersonConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public long PersonId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", PersonId);

        public IProcessResult<IPerson> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IPerson>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
