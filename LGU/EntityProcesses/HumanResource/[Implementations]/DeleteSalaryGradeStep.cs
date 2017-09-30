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
    public sealed class DeleteSalaryGradeStep : SalaryGradeStepProcess, IDeleteSalaryGradeStep
    {
        public DeleteSalaryGradeStep(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGradeStep SalaryGradeStep { get; set; }

        private SqlQueryInfo<ISalaryGradeStep> QueryInfo =>
            SqlQueryInfo<ISalaryGradeStep>.CreateProcedureQueryInfo(SalaryGradeStep, GetQualifiedDbObjectName(), GetProcessResult, true)
                .AddInputParameter("@_Id", SalaryGradeStep.Id)
                .AddLogByParameter();

        private IProcessResult<ISalaryGradeStep> GetProcessResult(ISalaryGradeStep SalaryGradeStep, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ISalaryGradeStep>(SalaryGradeStep);
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Failed to delete salary grade step.");
            }
        }

        public IProcessResult<ISalaryGradeStep> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
