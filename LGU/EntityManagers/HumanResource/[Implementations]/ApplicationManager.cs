using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationManager : ManagerBase<IApplication, long>, IApplicationManager
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

        public IProcessResult<IApplication> Delete(IApplication data)
        {
            if (data != null)
            {
                r_Delete.Application = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<IApplication>> DeleteAsync(IApplication data)
        {
            if (data != null)
            {
                r_Delete.Application = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<IApplication>> DeleteAsync(IApplication data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.Application = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public IProcessResult<IApplication> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplication>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public async Task<IProcessResult<IApplication>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplication>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public async Task<IProcessResult<IApplication>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplication>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application identifier.");
            }
        }

        public IEnumerableProcessResult<IApplication> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IApplication>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IApplication>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IApplication> Insert(IApplication data)
        {
            if (data != null)
            {
                r_Insert.Application = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<IApplication>> InsertAsync(IApplication data)
        {
            if (data != null)
            {
                r_Insert.Application = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<IApplication>> InsertAsync(IApplication data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.Application = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public IProcessResult<IApplication> Update(IApplication data)
        {
            if (data != null)
            {
                r_Update.Application = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<IApplication>> UpdateAsync(IApplication data)
        {
            if (data != null)
            {
                r_Update.Application = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }

        public async Task<IProcessResult<IApplication>> UpdateAsync(IApplication data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.Application = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IApplication>(ProcessResultStatus.Failed, "Invalid application.");
            }
        }
    }
}
