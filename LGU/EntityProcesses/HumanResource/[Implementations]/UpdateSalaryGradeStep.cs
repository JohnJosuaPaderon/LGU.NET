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
    public sealed class UpdateSalaryGradeStep : SalaryGradeStepProcess, IUpdateSalaryGradeStep
    {
        public UpdateSalaryGradeStep(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGradeStep SalaryGradeStep { get; set; }

        public SqlQueryInfo<ISalaryGradeStep> QueryInfo =>
            SqlQueryInfo<ISalaryGradeStep>.CreateProcedureQueryInfo(SalaryGradeStep, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_Id", SalaryGradeStep.Id)
            .AddInputParameter("@_SalaryGradeId", SalaryGradeStep.SalaryGrade?.Id)
            .AddInputParameter("@_Step", SalaryGradeStep.Step)
            .AddInputParameter("@_Amount", SalaryGradeStep.Amount)
            .AddLogByParameter();

        private IProcessResult<ISalaryGradeStep> GetProcessResult(ISalaryGradeStep data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<ISalaryGradeStep>(SalaryGradeStep);
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Failed to update salary grade step.");
            }
        }

        public IProcessResult<ISalaryGradeStep> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<ISalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
