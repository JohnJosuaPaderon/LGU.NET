using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationManager : ManagerBase<Application, long>, IApplicationManager
    {
        private readonly IDeleteApplication r_Delete;
        private readonly IGetApplicationById r_GetById;
        private readonly IGetApplicationList r_GetList;
        private readonly IInsertApplication r_Insert;
        private readonly IUpdateApplication r_Update;

        public ApplicationManager(
            IDeleteApplication delete,
            IGetApplicationById getById,
            IGetApplicationList getList,
            IInsertApplication insert,
            IUpdateApplication update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<Application> Delete(Application data)
        {
            if (data != null)
            {
                r_Delete.Application = data;
                return RemoveIfSuccess(r_Delete.Execute());
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
                r_Delete.Application = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
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
                r_Delete.Application = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
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
                    r_GetById.ApplicationId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
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
                    r_GetById.ApplicationId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
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
                    r_GetById.ApplicationId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public IEnumerableProcessResult<Application> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<Application>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<Application>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<Application> Insert(Application data)
        {
            if (data != null)
            {
                r_Insert.Application = data;
                return AddIfSuccess(r_Insert.Execute());
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
                r_Insert.Application = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
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
                r_Insert.Application = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
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
                r_Update.Application = data;
                return UpdateIfSuccess(r_Update.Execute());
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
                r_Update.Application = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
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
                r_Update.Application = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<Application>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }
    }
}
