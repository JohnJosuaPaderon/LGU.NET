using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationStatusManager : ManagerBase<ApplicationStatus, short>, IApplicationStatusManager
    {
        private readonly IGetApplicationStatusById r_GetApplicationStatusById;
        private readonly IGetApplicationStatusList r_GetApplicationStatusList;

        public ApplicationStatusManager(
            IGetApplicationStatusById getApplicationStatusById,
            IGetApplicationStatusList getApplicationStatusList)
        {
            r_GetApplicationStatusById = getApplicationStatusById;
            r_GetApplicationStatusList = getApplicationStatusList;
        }

        public IProcessResult<ApplicationStatus> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicationStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetApplicationStatusById.ApplicationStatusId = id;
                    var result = r_GetApplicationStatusById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<ApplicationStatus>(ProcessResultStatus.Failed, "Invalid application status identifier.");
            }
        }

        public async Task<IProcessResult<ApplicationStatus>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicationStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetApplicationStatusById.ApplicationStatusId = id;
                    var result = await r_GetApplicationStatusById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<ApplicationStatus>(ProcessResultStatus.Failed, "Invalid application status identifier.");
            }
        }

        public async Task<IProcessResult<ApplicationStatus>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicationStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetApplicationStatusById.ApplicationStatusId = id;
                    var result = await r_GetApplicationStatusById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<ApplicationStatus>(ProcessResultStatus.Failed, "Invalid application status identifier.");
            }
        }

        public IEnumerableProcessResult<ApplicationStatus> GetList()
        {
            var result = r_GetApplicationStatusList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ApplicationStatus>> GetListAsync()
        {
            var result = await r_GetApplicationStatusList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ApplicationStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetApplicationStatusList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
