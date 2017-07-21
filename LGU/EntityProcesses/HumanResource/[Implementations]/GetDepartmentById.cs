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
    public sealed class GetDepartmentById : HumanResourceProcessBase, IGetDepartmentById
    {
        private readonly IDepartmentConverter<SqlDataReader> Converter;

        public GetDepartmentById(IConnectionStringSource connectionStringSource, IDepartmentConverter<SqlDataReader> converter) : base(connectionStringSource)
        {
            Converter = converter;
        }

        public int DepartmentId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", DepartmentId);

        public IProcessResult<Department> Execute()
        {
            return SqlHelper.ExecuteReader(QueryInfo, Converter);
        }

        public Task<IProcessResult<Department>> ExecuteAsync()
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter);
        }

        public Task<IProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return SqlHelper.ExecuteReaderAsync(QueryInfo, Converter, cancellationToken);
        }
    }
}
