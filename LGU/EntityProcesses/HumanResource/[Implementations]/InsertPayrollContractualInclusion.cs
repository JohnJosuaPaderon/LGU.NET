using LGU.Data.Extensions;
using LGU.Data.Rdbms;
using LGU.Entities.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class InsertPayrollContractualInclusion : HumanResourceProcessBaseV2, IInsertPayrollContractualInclusion
    {
        private const string MESSAGE_FAILED = "Failed to insert Payroll Contractual Inclusion.";

        public InsertPayrollContractualInclusion(IConnectionStringSource connectionStringSource, IPayrollContractualInclusionParameters parameters) : base(connectionStringSource)
        {
            _Parameters = parameters;
        }

        private readonly IPayrollContractualInclusionParameters _Parameters;

        public IPayrollContractualInclusion PayrollContractualInclusion { get; set; }

        private SqlQueryInfo<IPayrollContractualInclusion> QueryInfo =>
            SqlQueryInfo<IPayrollContractualInclusion>.CreateProcedureQueryInfo(PayrollContractualInclusion, GetQualifiedDbObjectName(), GetProcessResult)
            .AddInputParameter(_Parameters.PayrollId, PayrollContractualInclusion.Payroll?.Id)
            .AddInputParameter(_Parameters.HdmfPremiumPs, PayrollContractualInclusion.HdmfPremiumPs);

        private IProcessResult<IPayrollContractualInclusion> GetProcessResult(IPayrollContractualInclusion data, SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                return new ProcessResult<IPayrollContractualInclusion>(data, ProcessResultStatus.Success);
            }
            else
            {
                return new ProcessResult<IPayrollContractualInclusion>(ProcessResultStatus.Failed, MESSAGE_FAILED);
            }
        }

        public IProcessResult<IPayrollContractualInclusion> Execute(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQuery(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IPayrollContractualInclusion>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction);
        }

        public Task<IProcessResult<IPayrollContractualInclusion>> ExecuteAsync(SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            return _SqlHelper.ExecuteNonQueryAsync(QueryInfo, connection, transaction, cancellationToken);
        }
    }
}
