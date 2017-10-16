using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.EntityConverters.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertSalaryGradeStep : SalaryGradeStepProcess, IInsertSalaryGradeStep
    {
        public InsertSalaryGradeStep(IConnectionStringSource connectionStringSource, ISalaryGradeStepConverter converter) : base(connectionStringSource, converter)
        {
        }

        public ISalaryGradeStep SalaryGradeStep { get; set; }

        private SqlQueryInfo<ISalaryGradeStep> QueryInfo =>
            SqlQueryInfo<ISalaryGradeStep>.CreateProcedureQueryInfo(SalaryGradeStep, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter("@_Id", DbType.Int64)
            .AddInputParameter("@_SalaryGradeId", SalaryGradeStep.SalaryGrade?.Id)
            .AddInputParameter("@_Step", SalaryGradeStep.Step)
            .AddInputParameter("@_Amount", SalaryGradeStep.Amount)
            .AddLogByParameter();

        private IProcessResult<ISalaryGradeStep> GetProcessResult(ISalaryGradeStep data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                data.Id = command.Parameters.GetInt64("@_Id");
                return new ProcessResult<ISalaryGradeStep>(SalaryGradeStep);
            }
            else
            {
                return new ProcessResult<ISalaryGradeStep>(ProcessResultStatus.Failed, "Failed to insert salary grade step.");
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
