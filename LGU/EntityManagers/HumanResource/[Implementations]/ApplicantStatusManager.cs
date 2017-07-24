using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicantStatusManager : ManagerBase<ApplicantStatus, short>, IApplicantStatusManager
    {
        private readonly IGetApplicantStatusById r_GetApplicantStatusById;
        private readonly IGetApplicantStatusList r_GetApplicantStatusList;

        public ApplicantStatusManager(
            IGetApplicantStatusById getApplicantStatusById,
            IGetApplicantStatusList getApplicantStatusList)
        {
            r_GetApplicantStatusById = getApplicantStatusById;
            r_GetApplicantStatusList = getApplicantStatusList;
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
                    r_GetApplicantStatusById.ApplicantStatusId = id;
                    var result = r_GetApplicantStatusById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
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
                    r_GetApplicantStatusById.ApplicantStatusId = id;
                    var result = await r_GetApplicantStatusById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
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
                    r_GetApplicantStatusById.ApplicantStatusId = id;
                    var result = await r_GetApplicantStatusById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<ApplicantStatus>(ProcessResultStatus.Failed, "Invalid applicant status identifier.");
            }
        }

        public IEnumerableProcessResult<ApplicantStatus> GetList()
        {
            var result = r_GetApplicantStatusList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ApplicantStatus>> GetListAsync()
        {
            var result = await r_GetApplicantStatusList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ApplicantStatus>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetApplicantStatusList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
