using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationDocumentManager : ManagerBase<ApplicationDocument, long>, IApplicationDocumentManager
    {
        private readonly IDeleteApplicationDocument r_Delete;
        private readonly IGetApplicationDocumentById r_GetById;
        private readonly IGetApplicationDocumentList r_GetList;
        private readonly IInsertApplicationDocument r_Insert;
        private readonly IUpdateApplicationDocument r_Update;

        public ApplicationDocumentManager(
            IDeleteApplicationDocument delete,
            IGetApplicationDocumentById getById,
            IGetApplicationDocumentList getList,
            IInsertApplicationDocument insert,
            IUpdateApplicationDocument update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<ApplicationDocument> Delete(ApplicationDocument data)
        {
            if (data != null)
            {
                r_Delete.ApplicationDocument = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> DeleteAsync(ApplicationDocument data)
        {
            if (data != null)
            {
                r_Delete.ApplicationDocument = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> DeleteAsync(ApplicationDocument data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.ApplicationDocument = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public IProcessResult<ApplicationDocument> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicationDocument>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationDocumentId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicationDocument>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationDocumentId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<ApplicationDocument>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationDocumentId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public IEnumerableProcessResult<ApplicationDocument> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<ApplicationDocument>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<ApplicationDocument>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<ApplicationDocument> Insert(ApplicationDocument data)
        {
            if (data != null)
            {
                r_Insert.ApplicationDocument = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> InsertAsync(ApplicationDocument data)
        {
            if (data != null)
            {
                r_Insert.ApplicationDocument = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> InsertAsync(ApplicationDocument data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.ApplicationDocument = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public IProcessResult<ApplicationDocument> Update(ApplicationDocument data)
        {
            if (data != null)
            {
                r_Update.ApplicationDocument = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> UpdateAsync(ApplicationDocument data)
        {
            if (data != null)
            {
                r_Update.ApplicationDocument = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<ApplicationDocument>> UpdateAsync(ApplicationDocument data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.ApplicationDocument = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }
    }
}
