using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentListWithTimeLog : DepartmentProcess, IGetDepartmentListWithTimeLog
    {
        public GetDepartmentListWithTimeLog(IConnectionStringSource connectionStringSource, IDepartmentConverter converter) : base(connectionStringSource, converter)
        {
        }

        public ValueRange<DateTime> CutOff { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_CutOffBegin", CutOff.Begin)
            .AddInputParameter("@_CutOffEnd", CutOff.End);

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
