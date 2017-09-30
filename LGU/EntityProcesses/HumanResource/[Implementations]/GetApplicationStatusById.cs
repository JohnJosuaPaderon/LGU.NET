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
    public sealed class GetApplicationStatusById : ApplicationStatusProcess, IGetApplicationStatusById
    {
        public GetApplicationStatusById(IConnectionStringSource connectionStringSource, IApplicationStatusConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public short ApplicationStatusId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", ApplicationStatusId);

        public IProcessResult<IApplicationStatus> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IApplicationStatus>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IApplicationStatus>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
