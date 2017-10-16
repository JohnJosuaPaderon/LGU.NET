using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentHeadById : DepartmentHeadProcess, IGetDepartmentHeadById
    {
        public GetDepartmentHeadById(IConnectionStringSource connectionStringSource, IDepartmentHeadConverter converter) : base(connectionStringSource, converter)
        {
        }

        public long DepartmentHeadId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", DepartmentHeadId);

        public IProcessResult<IDepartmentHead> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<IDepartmentHead>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
