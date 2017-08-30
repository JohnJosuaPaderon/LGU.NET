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
    public sealed class GetSalaryGradeBatchById : SalaryGradeBatchProcess, IGetSalaryGradeBatchById
    {
        public GetSalaryGradeBatchById(IConnectionStringSource connectionStringSource, ISalaryGradeBatchConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public int SalaryGradeBatchId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", SalaryGradeBatchId);

        public IProcessResult<ISalaryGradeBatch> Execute()
        {
            return r_SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<ISalaryGradeBatch>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
