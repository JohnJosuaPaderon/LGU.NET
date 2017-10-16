using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetSalaryGradeStepById : SalaryGradeStepProcess, IGetSalaryGradeStepById
    {
        public GetSalaryGradeStepById(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter converter) : base(connectionStringSource, converter)
        {
        }

        public long SalaryGradeStepId { get; set; }

        private SqlQueryInfo QueryInfo =>
            SqlQueryInfo.CreateProcedureQueryInfo(GetQualifiedDbObjectName())
                .AddInputParameter("@_Id", SalaryGradeStepId);

        public IProcessResult<ISalaryGradeStep> Execute()
        {
            return _SqlHelper.ExecuteReader(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteReaderAsync(QueryInfo, _Converter, cancellationToken);
        }
    }
}
