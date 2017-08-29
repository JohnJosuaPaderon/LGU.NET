using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class LocatorManager : ManagerBase<ILocator, long>, ILocatorManager
    {
        private readonly IDeleteLocator r_Delete;
        private readonly IGetLocatorById r_GetById;
        private readonly IGetLocatorList r_GetList;
        private readonly IInsertLocator r_Insert;
        private readonly IUpdateLocator r_Update;

        public LocatorManager(
            IDeleteLocator delete,
            IGetLocatorById getById,
            IGetLocatorList getList,
            IInsertLocator insert,
            IUpdateLocator update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<ILocator> Delete(ILocator data)
        {
            if (data != null)
            {
                r_Delete.Locator = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public async Task<IProcessResult<ILocator>> DeleteAsync(ILocator data)
        {
            if (data != null)
            {
                r_Delete.Locator = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public async Task<IProcessResult<ILocator>> DeleteAsync(ILocator data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.Locator = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public IProcessResult<ILocator> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ILocator>(StaticSource[id]);
                }
                else
                {
                    r_GetById.LocatorId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator identifier.");
            }
        }

        public async Task<IProcessResult<ILocator>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ILocator>(StaticSource[id]);
                }
                else
                {
                    r_GetById.LocatorId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator identifier.");
            }
        }

        public async Task<IProcessResult<ILocator>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ILocator>(StaticSource[id]);
                }
                else
                {
                    r_GetById.LocatorId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator identifier.");
            }
        }

        public IEnumerableProcessResult<ILocator> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<ILocator>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<ILocator>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<ILocator> Insert(ILocator data)
        {
            if (data != null)
            {
                r_Insert.Locator = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public async Task<IProcessResult<ILocator>> InsertAsync(ILocator data)
        {
            if (data != null)
            {
                r_Insert.Locator = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public async Task<IProcessResult<ILocator>> InsertAsync(ILocator data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.Locator = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public IProcessResult<ILocator> Update(ILocator data)
        {
            if (data != null)
            {
                r_Update.Locator = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public async Task<IProcessResult<ILocator>> UpdateAsync(ILocator data)
        {
            if (data != null)
            {
                r_Update.Locator = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }

        public async Task<IProcessResult<ILocator>> UpdateAsync(ILocator data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.Locator = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ILocator>(ProcessResultStatus.Failed, "Invalid locator.");
            }
        }
    }
}
