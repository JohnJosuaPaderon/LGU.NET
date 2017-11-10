using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollContractualInclusionManager : IPayrollContractualInclusionManager
    {
        private const string MESSAGE_INVALID = "Invalid Payroll Contractual Inclusion.";
        private const string MESSAGE_INVALID_PAYROLL_CONTRACTUAL = "Invalid Payroll Contractual.";

        public PayrollContractualInclusionManager(
            IGetPayrollContractualInclusion get,
            IInsertPayrollContractualInclusion insert)
        {
            _Get = get;
            _Insert = insert;

            _InvalidResult = new ProcessResult<IPayrollContractualInclusion>(ProcessResultStatus.Failed, MESSAGE_INVALID);
            _InvalidPayrollContractualResult = new ProcessResult<IPayrollContractualInclusion>(ProcessResultStatus.Failed, MESSAGE_INVALID_PAYROLL_CONTRACTUAL);
        }

        private readonly IGetPayrollContractualInclusion _Get;
        private readonly IInsertPayrollContractualInclusion _Insert;
        private readonly IProcessResult<IPayrollContractualInclusion> _InvalidResult;
        private readonly IProcessResult<IPayrollContractualInclusion> _InvalidPayrollContractualResult;

        public IProcessResult<IPayrollContractualInclusion> Get(IPayrollContractual payrollContractual)
        {
            if (payrollContractual != null)
            {
                _Get.Payroll = payrollContractual;
                return _Get.Execute();
            }
            else
            {
                return _InvalidPayrollContractualResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualInclusion>> GetAsync(IPayrollContractual payrollContractual)
        {
            if (payrollContractual != null)
            {
                _Get.Payroll = payrollContractual;
                return await _Get.ExecuteAsync();
            }
            else
            {
                return _InvalidPayrollContractualResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualInclusion>> GetAsync(IPayrollContractual payrollContractual, CancellationToken cancellationToken)
        {
            if (payrollContractual != null)
            {
                _Get.Payroll = payrollContractual;
                return await _Get.ExecuteAsync(cancellationToken);
            }
            else
            {
                return _InvalidPayrollContractualResult;
            }
        }

        public IProcessResult<IPayrollContractualInclusion> Insert(IPayrollContractualInclusion payrollContractualInclusion, SqlConnection connection, SqlTransaction transaction)
        {
            if (payrollContractualInclusion != null)
            {
                _Insert.PayrollContractualInclusion = payrollContractualInclusion;
                return _Insert.Execute(connection, transaction);
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualInclusion>> InsertAsync(IPayrollContractualInclusion payrollContractualInclusion, SqlConnection connection, SqlTransaction transaction)
        {
            if (payrollContractualInclusion != null)
            {
                _Insert.PayrollContractualInclusion = payrollContractualInclusion;
                return await _Insert.ExecuteAsync(connection, transaction);
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractualInclusion>> InsertAsync(IPayrollContractualInclusion payrollContractualInclusion, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (payrollContractualInclusion != null)
            {
                _Insert.PayrollContractualInclusion = payrollContractualInclusion;
                return await _Insert.ExecuteAsync(connection, transaction, cancellationToken);
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
