using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class LocatorLeaveTypeManager : ManagerBase<LocatorLeaveType, short>, ILocatorLeaveTypeManager
    {
        private readonly IGetLocatorLeaveTypeById r_GetById;
        private readonly IGetLocatorLeaveTypeList r_GetList;

        public LocatorLeaveTypeManager(
            IGetLocatorLeaveTypeById getById,
            IGetLocatorLeaveTypeList getList)
        {
            r_GetById = getById;
            r_GetList = getList;
        }

        public IProcessResult<LocatorLeaveType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<LocatorLeaveType>(StaticSource[id]);
                }
                else
                {
                    r_GetById.LocatorLeaveTypeId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<LocatorLeaveType>(ProcessResultStatus.Failed, "Invalid locator leave type identifier.");
            }
        }

        public async Task<IProcessResult<LocatorLeaveType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<LocatorLeaveType>(StaticSource[id]);
                }
                else
                {
                    r_GetById.LocatorLeaveTypeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<LocatorLeaveType>(ProcessResultStatus.Failed, "Invalid locator leave type identifier.");
            }
        }

        public async Task<IProcessResult<LocatorLeaveType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<LocatorLeaveType>(StaticSource[id]);
                }
                else
                {
                    r_GetById.LocatorLeaveTypeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<LocatorLeaveType>(ProcessResultStatus.Failed, "Invalid locator leave type identifier.");
            }
        }

        public IEnumerableProcessResult<LocatorLeaveType> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<LocatorLeaveType>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<LocatorLeaveType>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }
    }
}
