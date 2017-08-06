using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicantManager : ManagerBase<Applicant, long>, IApplicantManager
    {
        private readonly IDeleteApplicant r_Delete;
        private readonly IGetApplicantById r_GetById;
        private readonly IGetApplicantList r_GetList;
        private readonly IInsertApplicant r_Insert;
        private readonly IUpdateApplicant r_Update;

        public ApplicantManager(
            IDeleteApplicant delete,
            IGetApplicantById getById,
            IGetApplicantList getList,
            IInsertApplicant insert,
            IUpdateApplicant update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<Applicant> Delete(Applicant data)
        {
            if (data != null)
            {
                r_Delete.Applicant = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public async Task<IProcessResult<Applicant>> DeleteAsync(Applicant data)
        {
            if (data != null)
            {
                r_Delete.Applicant = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public async Task<IProcessResult<Applicant>> DeleteAsync(Applicant data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.Applicant = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public IProcessResult<Applicant> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Applicant>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicantId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant identifier.");
            }
        }

        public async Task<IProcessResult<Applicant>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Applicant>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicantId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant identifier.");
            }
        }

        public async Task<IProcessResult<Applicant>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Applicant>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicantId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant identifier.");
            }
        }

        public IEnumerableProcessResult<Applicant> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<Applicant>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<Applicant>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<Applicant> Insert(Applicant data)
        {
            if (data != null)
            {
                r_Insert.Applicant = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public async Task<IProcessResult<Applicant>> InsertAsync(Applicant data)
        {
            if (data != null)
            {
                r_Insert.Applicant = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public async Task<IProcessResult<Applicant>> InsertAsync(Applicant data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.Applicant = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public IProcessResult<Applicant> Update(Applicant data)
        {
            if (data != null)
            {
                r_Update.Applicant = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public async Task<IProcessResult<Applicant>> UpdateAsync(Applicant data)
        {
            if (data != null)
            {
                r_Update.Applicant = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }

        public async Task<IProcessResult<Applicant>> UpdateAsync(Applicant data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.Applicant = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }
    }
}
