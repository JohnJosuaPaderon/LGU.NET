using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertPayrollContractualEmployee : HumanResourceProcessBaseV2, IInsertPayrollContractualEmployee
    {
        private const string MESSAGE_FAILED = "Failed to insert payroll contractual employee.";

        public InsertPayrollContractualEmployee(IConnectionStringSource connectionStringSource, IPayrollContractualEmployeeParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly IPayrollContractualEmployeeParameters _Parameters;

        public IPayrollContractualEmployee PayrollContractualEmployee { get; set; }

        private SqlQueryInfo<IPayrollContractualEmployee> QueryInfo =>
            SqlQueryInfo<IPayrollContractualEmployee>.CreateProcedureQueryInfo(PayrollContractualEmployee, GetQualifiedDbObjectName(), GetProcessResult, true)
            .AddOutputParameter(_Parameters.Id, DbType.Int64)
            .AddInputParameter(_Parameters.EmployeeId, PayrollContractualEmployee.Employee?.Id)
            .AddInputParameter(_Parameters.DepartmentId, PayrollContractualEmployee.Department?.Id)
            .AddInputParameter(_Parameters.MonthlyRate, PayrollContractualEmployee.MonthlyRate)
            .AddInputParameter(_Parameters.TimeLogDeduction, PayrollContractualEmployee.TimeLogDeduction)
            .AddInputParameter(_Parameters.WithholdingTax, PayrollContractualEmployee.WithholdingTax)
            .AddInputParameter(_Parameters.HdmfPremiumPs, PayrollContractualEmployee.HdmfPremiumPs)
            .AddLogByParameter();

        private IProcessResult<IPayrollContractualEmployee> GetProcessResult(IPayrollContractualEmployee data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IPayrollContractualEmployee>(data);
            }
            else
            {
                return new ProcessResult<IPayrollContractualEmployee>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IPayrollContractualEmployee> Execute()
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo);
        }

        public IProcessResult<IPayrollContractualEmployee> Execute(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IPayrollContractualEmployee>> ExecuteAsync()
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<IPayrollContractualEmployee>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }

        public Task<IProcessResult<IPayrollContractualEmployee>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IPayrollContractualEmployee>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction, cancellationToken);
        }
    }
}
