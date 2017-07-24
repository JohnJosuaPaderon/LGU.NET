using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Text;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;
using LGU.EntityProcesses.HumanResource;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicantManager : ManagerBase<Applicant, long>, IApplicantManager
    {
        private readonly IDeleteApplicant r_DeleteApplicant;
        private readonly IGetApplicantById r_GetApplicantById;
        private readonly IGetApplicantList r_GetApplicantList;
        private readonly IInsertApplicant r_InsertApplicant;
        private readonly IUpdateApplicant r_UpdateApplicant;

        public ApplicantManager(
            IDeleteApplicant deleteApplicant,
            IGetApplicantById getApplicantById,
            IGetApplicantList getApplicantList,
            IInsertApplicant insertApplicant,
            IUpdateApplicant updateApplicant)
        {
            r_DeleteApplicant = deleteApplicant;
            r_GetApplicantById = getApplicantById;
            r_GetApplicantList = getApplicantList;
            r_InsertApplicant = insertApplicant;
            r_UpdateApplicant = updateApplicant;
        }

        public IProcessResult<Applicant> Delete(Applicant data)
        {
            if (data != null)
            {
                r_DeleteApplicant.Applicant = data;
                var result = r_DeleteApplicant.Execute();
                RemoveIfSuccess(result);

                return result;
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
                r_DeleteApplicant.Applicant = data;
                var result = await r_DeleteApplicant.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
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
                r_DeleteApplicant.Applicant = data;
                var result = await r_DeleteApplicant.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
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
                    r_GetApplicantById.ApplicantId = id;
                    var result = r_GetApplicantById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
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
                    r_GetApplicantById.ApplicantId = id;
                    var result = await r_GetApplicantById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
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
                    r_GetApplicantById.ApplicantId = id;
                    var result = await r_GetApplicantById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant identifier.");
            }
        }

        public IEnumerableProcessResult<Applicant> GetList()
        {
            var result = r_GetApplicantList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Applicant>> GetListAsync()
        {
            var result = await r_GetApplicantList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Applicant>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetApplicantList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Applicant> Insert(Applicant data)
        {
            if (data != null)
            {
                r_InsertApplicant.Applicant = data;
                var result = r_InsertApplicant.Execute();
                AddIfSuccess(result);

                return result;
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
                r_InsertApplicant.Applicant = data;
                var result = await r_InsertApplicant.ExecuteAsync();
                AddIfSuccess(result);

                return result;
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
                r_InsertApplicant.Applicant = data;
                var result = await r_InsertApplicant.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
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
                r_UpdateApplicant.Applicant = data;
                var result = r_UpdateApplicant.Execute();
                UpdateIfSuccess(result);

                return result;
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
                r_UpdateApplicant.Applicant = data;
                var result = await r_UpdateApplicant.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
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
                r_UpdateApplicant.Applicant = data;
                var result = await r_UpdateApplicant.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Applicant>(ProcessResultStatus.Failed, "Invalid applicant.");
            }
        }
    }
}
