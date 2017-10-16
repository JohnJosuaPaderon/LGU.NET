using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentById : DepartmentProcess, IGetDepartmentById
    {
        public GetDepartmentById(IConnectionStringSource connectionStringSource, IDepartmentConverter converter) : base(connectionStringSource, converter)
        {
        }

        public int DepartmentId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", DepartmentId);

        public IProcessResult<IDepartment> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IDepartment>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IDepartment>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
