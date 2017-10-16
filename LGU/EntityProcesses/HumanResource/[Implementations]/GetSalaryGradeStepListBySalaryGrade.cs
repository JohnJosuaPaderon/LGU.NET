using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetSalaryGradeStepListBySalaryGrade : SalaryGradeStepProcess, IGetSalaryGradeStepListBySalaryGrade
    {
        public GetSalaryGradeStepListBySalaryGrade(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGrade SalaryGrade { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
            .AddInputParameter("@_SalaryGradeId", SalaryGrade.Id);

        public IEnumerableProcessResult<ISalaryGradeStep> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<ISalaryGradeStep>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<ISalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
