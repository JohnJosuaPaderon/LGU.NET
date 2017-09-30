using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationStatusManager : EntityManagerBase<IApplicationStatus, short>, IApplicationStatusManager
    {
        private readonly IGetApplicationStatusById r_GetById;
        private readonly IGetApplicationStatusList r_GetList;

        public ApplicationStatusManager(
            IGetApplicationStatusById getById,
            IGetApplicationStatusList getList)
        {
            r_GetById = getById;
            r_GetList = getList;
        }

        public IProcessResult<IApplicationStatus> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplicationStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationStatusId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IApplicationStatus>(ProcessResultStatus.Failed, "Invalid application status identifier.");
            }
        }

        public async Task<IProcessResult<IApplicationStatus>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplicationStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationStatusId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IApplicationStatus>(ProcessResultStatus.Failed, "Invalid application status identifier.");
            }
        }

        public async Task<IProcessResult<IApplicationStatus>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplicationStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationStatusId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IApplicationStatus>(ProcessResultStatus.Failed, "Invalid application status identifier.");
            }
        }

        public IEnumerableProcessResult<IApplicationStatus> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IApplicationStatus>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IApplicationStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }
    }
}
