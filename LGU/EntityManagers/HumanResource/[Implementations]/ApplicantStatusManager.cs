using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicantStatusManager : ManagerBase<ApplicantStatus, short>, IApplicantStatusManager
    {
        private readonly IGetApplicantStatusById r_GetById;
        private readonly IGetApplicantStatusList r_GetList;

        public ApplicantStatusManager(
            IGetApplicantStatusById getById,
            IGetApplicantStatusList getList)
        {
            r_GetById = getById;
            r_GetList = getList;
        }

        public IProcessResult<ApplicantStatus> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicantStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicantStatusId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<ApplicantStatus>(ProcessResultStatus.Failed, "Invalid applicant status identifier.");
            }
        }

        public async Task<IProcessResult<ApplicantStatus>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicantStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicantStatusId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<ApplicantStatus>(ProcessResultStatus.Failed, "Invalid applicant status identifier.");
            }
        }

        public async Task<IProcessResult<ApplicantStatus>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicantStatus>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicantStatusId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<ApplicantStatus>(ProcessResultStatus.Failed, "Invalid applicant status identifier.");
            }
        }

        public IEnumerableProcessResult<ApplicantStatus> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<ApplicantStatus>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<ApplicantStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }
    }
}
