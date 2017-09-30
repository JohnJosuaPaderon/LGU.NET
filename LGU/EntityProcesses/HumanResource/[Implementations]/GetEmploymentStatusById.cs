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
    public sealed class GetEmploymentStatusById : EmploymentStatusProcess, IGetEmploymentStatusById
    {
        public GetEmploymentStatusById(IConnectionStringSource connectionStringSource, IEmploymentStatusConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public short EmploymentStatusId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_Id", EmploymentStatusId);

        public IProcessResult<IEmploymentStatus> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IEmploymentStatus>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter);
        }

        public Task<IProcessResult<IEmploymentStatus>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, r_Converter, cancellationToken);
        }
    }
}
