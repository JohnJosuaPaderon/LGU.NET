using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollCutOffManager : EntityManagerBase<IPayrollCutOff, short>, IPayrollCutOffManager
    {
        private const string MESSAGE_INVALID_ID = "Invalid payroll cut-off identifier.";

        public PayrollCutOffManager(
            IGetPayrollCutOffById getById,
            IGetPayrollCutOffList getList)
        {
            _GetById = getById;
            _GetList = getList;
        }

        private readonly IGetPayrollCutOffById _GetById;
        private readonly IGetPayrollCutOffList _GetList;

        public IProcessResult<IPayrollCutOff> GetById(short payrollCutOffId)
        {
            if (payrollCutOffId > 0)
            {
                if (StaticSource.ContainsId(payrollCutOffId))
                {
                    return new ProcessResult<IPayrollCutOff>(StaticSource[payrollCutOffId]);
                }
                else
                {
                    _GetById.PayrollCutOffId = payrollCutOffId;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IPayrollCutOff>(ProcessResultStatus.Failed, MESSAGE_INVALID_ID);
            }
        }

        public async Task<IProcessResult<IPayrollCutOff>> GetByIdAsync(short payrollCutOffId)
        {
            if (payrollCutOffId > 0)
            {
                if (StaticSource.ContainsId(payrollCutOffId))
                {
                    return new ProcessResult<IPayrollCutOff>(StaticSource[payrollCutOffId]);
                }
                else
                {
                    _GetById.PayrollCutOffId = payrollCutOffId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IPayrollCutOff>(ProcessResultStatus.Failed, MESSAGE_INVALID_ID);
            }
        }

        public async Task<IProcessResult<IPayrollCutOff>> GetByIdAsync(short payrollCutOffId, CancellationToken cancellationToken)
        {
            if (payrollCutOffId > 0)
            {
                if (StaticSource.ContainsId(payrollCutOffId))
                {
                    return new ProcessResult<IPayrollCutOff>(StaticSource[payrollCutOffId]);
                }
                else
                {
                    _GetById.PayrollCutOffId = payrollCutOffId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IPayrollCutOff>(ProcessResultStatus.Failed, MESSAGE_INVALID_ID);
            }
        }

        public IEnumerableProcessResult<IPayrollCutOff> GetList()
        {
            return AddUpdateIfSuccess(_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IPayrollCutOff>> GetListAsync()
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IPayrollCutOff>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync(cancellationToken));
        }
    }
}
