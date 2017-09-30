using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class PayrollTypeManager : EntityManagerBase<IPayrollType, short>, IPayrollTypeManager
    {
        private const string MESSAGE_INVALID_ID = "Invalid payroll type identifier.";

        public PayrollTypeManager(
            IGetPayrollTypeById getById,
            IGetPayrollTypeList getList)
        {
            _GetById = getById;
            _GetList = getList;
        }

        private readonly IGetPayrollTypeById _GetById;
        private readonly IGetPayrollTypeList _GetList;

        public IProcessResult<IPayrollType> GetById(short payrollTypeId)
        {
            if (payrollTypeId > 0)
            {
                if (StaticSource.ContainsId(payrollTypeId))
                {
                    return new ProcessResult<IPayrollType>(StaticSource[payrollTypeId]);
                }
                else
                {
                    _GetById.PayrollTypeId = payrollTypeId;
                    return AddUpdateIfSuccess(_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IPayrollType>(ProcessResultStatus.Failed, MESSAGE_INVALID_ID);
            }
        }

        public async Task<IProcessResult<IPayrollType>> GetByIdAsync(short payrollTypeId)
        {
            if (payrollTypeId > 0)
            {
                if (StaticSource.ContainsId(payrollTypeId))
                {
                    return new ProcessResult<IPayrollType>(StaticSource[payrollTypeId]);
                }
                else
                {
                    _GetById.PayrollTypeId = payrollTypeId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IPayrollType>(ProcessResultStatus.Failed, MESSAGE_INVALID_ID);
            }
        }

        public async Task<IProcessResult<IPayrollType>> GetByIdAsync(short payrollTypeId, CancellationToken cancellationToken)
        {
            if (payrollTypeId > 0)
            {
                if (StaticSource.ContainsId(payrollTypeId))
                {
                    return new ProcessResult<IPayrollType>(StaticSource[payrollTypeId]);
                }
                else
                {
                    _GetById.PayrollTypeId = payrollTypeId;
                    return AddUpdateIfSuccess(await _GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IPayrollType>(ProcessResultStatus.Failed, MESSAGE_INVALID_ID);
            }
        }

        public IEnumerableProcessResult<IPayrollType> GetList()
        {
            return AddUpdateIfSuccess(_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IPayrollType>> GetListAsync()
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IPayrollType>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await _GetList.ExecuteAsync(cancellationToken));
        }
    }
}
