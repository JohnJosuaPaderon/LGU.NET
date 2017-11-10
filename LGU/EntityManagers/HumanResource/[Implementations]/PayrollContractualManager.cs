using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollContractualManager : EntityManagerBase<IPayrollContractual, long>, IPayrollContractualManager
    {
        private const string MESSAGE_INVALID = "Invalid Payroll Contractual.";

        public PayrollContractualManager(IInsertPayrollContractual insert)
        {
            _Insert = insert;

            _InvalidResult = new ProcessResult<IPayrollContractual>(ProcessResultStatus.Failed, MESSAGE_INVALID);
        }

        private readonly IInsertPayrollContractual _Insert;
        private readonly IProcessResult<IPayrollContractual> _InvalidResult;

        public IProcessResult<IPayrollContractual> GetById(long payrollContractualId)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IPayrollContractual>> GetByIdAsync(long payrollContractualId)
        {
            throw new NotImplementedException();
        }

        public Task<IProcessResult<IPayrollContractual>> GetByIdAsync(long payrollContractualId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IProcessResult<IPayrollContractual> Insert(IPayrollContractual payrollContractual)
        {
            if (payrollContractual != null)
            {
                _Insert.PayrollContractual = payrollContractual;
                return AddUpdateIfSuccess(_Insert.Execute());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractual>> InsertAsync(IPayrollContractual payrollContractual)
        {
            if (payrollContractual != null)
            {
                _Insert.PayrollContractual = payrollContractual;
                return AddUpdateIfSuccess(await _Insert.ExecuteAsync());
            }
            else
            {
                return _InvalidResult;
            }
        }

        public async Task<IProcessResult<IPayrollContractual>> InsertAsync(IPayrollContractual payrollContractual, CancellationToken cancellationToken)
        {
            if (payrollContractual != null)
            {
                _Insert.PayrollContractual = payrollContractual;
                return AddUpdateIfSuccess(await _Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return _InvalidResult;
            }
        }
    }
}
