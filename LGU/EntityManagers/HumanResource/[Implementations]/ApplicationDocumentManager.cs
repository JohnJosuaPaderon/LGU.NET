using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationDocumentManager : EntityManagerBase<IApplicationDocument, long>, IApplicationDocumentManager
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

        public IProcessResult<IApplicationDocument> Delete(IApplicationDocument data)
        {
            if (data != null)
            {
                r_Delete.ApplicationDocument = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> DeleteAsync(IApplicationDocument data)
        {
            if (data != null)
            {
                r_Delete.ApplicationDocument = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> DeleteAsync(IApplicationDocument data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.ApplicationDocument = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public IProcessResult<IApplicationDocument> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplicationDocument>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationDocumentId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplicationDocument>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationDocumentId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IApplicationDocument>(StaticSource[id]);
                }
                else
                {
                    r_GetById.ApplicationDocumentId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public IEnumerableProcessResult<IApplicationDocument> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IApplicationDocument>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IApplicationDocument>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IApplicationDocument> Insert(IApplicationDocument data)
        {
            if (data != null)
            {
                r_Insert.ApplicationDocument = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> InsertAsync(IApplicationDocument data)
        {
            if (data != null)
            {
                r_Insert.ApplicationDocument = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> InsertAsync(IApplicationDocument data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.ApplicationDocument = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public IProcessResult<IApplicationDocument> Update(IApplicationDocument data)
        {
            if (data != null)
            {
                r_Update.ApplicationDocument = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> UpdateAsync(IApplicationDocument data)
        {
            if (data != null)
            {
                r_Update.ApplicationDocument = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }

        public async Task<IProcessResult<IApplicationDocument>> UpdateAsync(IApplicationDocument data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.ApplicationDocument = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }
    }
}
