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
    public sealed class InsertEmployeeSalaryGradeStep : EmployeeSalaryGradeStepProcess, IInsertEmployeeSalaryGradeStep
    {
        public InsertEmployeeSalaryGradeStep(IConnectionStringSource connectionStringSource, IEmployeeSalaryGradeStepConverter converter) : base(connectionStringSource, converter)
        {
        }

        public IEmployeeSalaryGradeStep EmployeeSalaryGradeStep { get; set; }

        private SqlQueryInfo<IEmployeeSalaryGradeStep> QueryInfo =>
            SqlQueryInfo<IEmployeeSalaryGradeStep>.CreateProcedureQueryInfo(EmployeeSalaryGradeStep, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_EmployeeId", EmployeeSalaryGradeStep.Employee?.Id)
            .AddInputParameter("@_SalaryGradeStepId", EmployeeSalaryGradeStep.SalaryGradeStep?.Id)
            .AddInputParameter("@_EffectivityDate", EmployeeSalaryGradeStep.EffectivityDate)
            .AddLogByParameter();

        private IProcessResult<IEmployeeSalaryGradeStep> GetProcessResult(IEmployeeSalaryGradeStep data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Failed to insert employee salary grade step.");
            }
        }

        public IProcessResult<IEmployeeSalaryGradeStep> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeSalaryGradeStep>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeSalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
