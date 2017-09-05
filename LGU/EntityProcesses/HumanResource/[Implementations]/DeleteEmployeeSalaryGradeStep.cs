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
    public sealed class DeleteEmployeeSalaryGradeStep : EmployeeSalaryGradeStepProcess, IDeleteEmployeeSalaryGradeStep
    {
        public DeleteEmployeeSalaryGradeStep(IConnectionStringSource connectionStringSource, IEmployeeSalaryGradeStepConverter<SqlDataReader> converter) : base(connectionStringSource, converter)
        {
        }

        public IEmployeeSalaryGradeStep EmployeeSalaryGradeStep { get; set; }

        private SqlQueryInfo<IEmployeeSalaryGradeStep> QueryInfo =>
            SqlQueryInfo<IEmployeeSalaryGradeStep>.CreateProcedureQueryInfo(EmployeeSalaryGradeStep, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddInputParameter("@_EmployeeId", EmployeeSalaryGradeStep.Employee?.Id)
            .AddInputParameter("@_SalaryGradeStepId", EmployeeSalaryGradeStep.SalaryGradeStep?.Id)
            .AddLogByParameter();

        private IProcessResult<IEmployeeSalaryGradeStep> GetProcessResult(IEmployeeSalaryGradeStep data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(data);
            }
            else
            {
                return new ProcessResult<IEmployeeSalaryGradeStep>(ProcessResultStatus.Failed, "Failed to delete employee salary grade step.");
            }
        }

        public IProcessResult<IEmployeeSalaryGradeStep> Execute()
        {
            return r_SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeSalaryGradeStep>> ExecuteAsync()
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IEmployeeSalaryGradeStep>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return r_SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
