using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationManager : ManagerBase<Application, long>, IApplicationManager
    {
        private readonly IDeleteApplication r_DeleteApplication;
        private readonly IGetApplicationById r_GetApplicationById;
        private readonly IGetApplicationList r_GetApplicationList;
        private readonly IInsertApplication r_InsertApplication;
        private readonly IUpdateApplication r_UpdateApplication;

        public ApplicationManager(
            IDeleteApplication deleteApplication,
            IGetApplicationById getApplicationById,
            IGetApplicationList getApplicationList,
            IInsertApplication insertApplication,
            IUpdateApplication updateApplication)
        {
            r_DeleteApplication = deleteApplication;
            r_GetApplicationById = getApplicationById;
            r_GetApplicationList = getApplicationList;
            r_InsertApplication = insertApplication;
            r_UpdateApplication = updateApplication;
        }

        public IProcessResult<Application> Delete(Application data)
        {
            if (data != null)
            {
                r_DeleteApplication.Application = data;
                var result = r_DeleteApplication.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<Application>> DeleteAsync(Application data)
        {
            if (data != null)
            {
                r_DeleteApplication.Application = data;
                var result = await r_DeleteApplication.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<Application>> DeleteAsync(Application data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteApplication.Application = data;
                var result = await r_DeleteApplication.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public IProcessResult<Application> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Application>(StaticSource[id]);
                }
                else
                {
                    r_GetApplicationById.ApplicationId = id;
                    var result = r_GetApplicationById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public async Task<IProcessResult<Application>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Application>(StaticSource[id]);
                }
                else
                {
                    r_GetApplicationById.ApplicationId = id;
                    var result = await r_GetApplicationById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public async Task<IProcessResult<Application>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Application>(StaticSource[id]);
                }
                else
                {
                    r_GetApplicationById.ApplicationId = id;
                    var result = await r_GetApplicationById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public IEnumerableProcessResult<Application> GetList()
        {
            var result = r_GetApplicationList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Application>> GetListAsync()
        {
            var result = await r_GetApplicationList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Application>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetApplicationList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Application> Insert(Application data)
        {
            if (data != null)
            {
                r_InsertApplication.Application = data;
                var result = r_InsertApplication.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<Application>> InsertAsync(Application data)
        {
            if (data != null)
            {
                r_InsertApplication.Application = data;
                var result = await r_InsertApplication.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<Application>> InsertAsync(Application data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertApplication.Application = data;
                var result = await r_InsertApplication.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public IProcessResult<Application> Update(Application data)
        {
            if (data != null)
            {
                r_UpdateApplication.Application = data;
                var result = r_UpdateApplication.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<Application>> UpdateAsync(Application data)
        {
            if (data != null)
            {
                r_UpdateApplication.Application = data;
                var result = await r_UpdateApplication.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<Application>> UpdateAsync(Application data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateApplication.Application = data;
                var result = await r_UpdateApplication.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }
    }
}
