using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetEmployeeSalaryGradeStepList : EmployeeSalaryGradeStepProcess, IGetEmployeeSalaryGradeStepList
    {
        public GetEmployeeSalaryGradeStepList(IConnectionStringSource connectionStringSource, IEmployeeSalaryGradeStepConverter converter) : base(connectionStringSource, converter)
        {
        }

        private SqlQueryInfo QueryInfo => SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName());

        public IEnumerableProcessResult<IEmployeeSalaryGradeStep> Execute()
        {
            return _SqlHelper.ExecuteReaderEnumerable(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter);
        }

        public Task<IEnumerableProcessResult<IEmployeeSalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderEnumerableAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
