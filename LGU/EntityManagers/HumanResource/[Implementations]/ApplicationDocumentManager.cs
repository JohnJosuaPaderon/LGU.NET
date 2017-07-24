using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class ApplicationDocumentManager : ManagerBase<ApplicationDocument, long>, IApplicationDocumentManager
    {
        private readonly IDeleteApplicationDocument r_DeleteApplicationDocument;
        private readonly IGetApplicationDocumentById r_GetApplicationDocumentById;
        private readonly IGetApplicationDocumentList r_GetApplicationDocumentList;
        private readonly IInsertApplicationDocument r_InsertApplicationDocument;
        private readonly IUpdateApplicationDocument r_UpdateApplicationDocument;

        public ApplicationDocumentManager(
            IDeleteApplicationDocument deleteApplicationDocument,
            IGetApplicationDocumentById getApplicationDocumentById,
            IGetApplicationDocumentList getApplicationDocumentList,
            IInsertApplicationDocument insertApplicationDocument,
            IUpdateApplicationDocument updateApplicationDocument)
        {
            r_DeleteApplicationDocument = deleteApplicationDocument;
            r_GetApplicationDocumentById = getApplicationDocumentById;
            r_GetApplicationDocumentList = getApplicationDocumentList;
            r_InsertApplicationDocument = insertApplicationDocument;
            r_UpdateApplicationDocument = updateApplicationDocument;
        }

        public IProcessResult<ApplicationDocument> Delete(ApplicationDocument data)
        {
            if (data != null)
            {
                r_DeleteApplicationDocument.ApplicationDocument = data;
                var result = r_DeleteApplicationDocument.Execute();
                RemoveIfSuccess(result);

                return result;
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
                r_DeleteApplicationDocument.ApplicationDocument = data;
                var result = await r_DeleteApplicationDocument.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
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
                r_DeleteApplicationDocument.ApplicationDocument = data;
                var result = await r_DeleteApplicationDocument.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
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
                    r_GetApplicationDocumentById.ApplicationDocumentId = id;
                    var result = r_GetApplicationDocumentById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
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
                    r_GetApplicationDocumentById.ApplicationDocumentId = id;
                    var result = await r_GetApplicationDocumentById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
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
                    r_GetApplicationDocumentById.ApplicationDocumentId = id;
                    var result = await r_GetApplicationDocumentById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document identifier.");
            }
        }

        public IEnumerableProcessResult<ApplicationDocument> GetList()
        {
            var result = r_GetApplicationDocumentList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ApplicationDocument>> GetListAsync()
        {
            var result = await r_GetApplicationDocumentList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<ApplicationDocument>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetApplicationDocumentList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<ApplicationDocument> Insert(ApplicationDocument data)
        {
            if (data != null)
            {
                r_InsertApplicationDocument.ApplicationDocument = data;
                var result = r_InsertApplicationDocument.Execute();
                AddIfSuccess(result);

                return result;
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
                r_InsertApplicationDocument.ApplicationDocument = data;
                var result = await r_InsertApplicationDocument.ExecuteAsync();
                AddIfSuccess(result);

                return result;
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
                r_InsertApplicationDocument.ApplicationDocument = data;
                var result = await r_InsertApplicationDocument.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
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
                r_UpdateApplicationDocument.ApplicationDocument = data;
                var result = r_UpdateApplicationDocument.Execute();
                UpdateIfSuccess(result);

                return result;
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
                r_UpdateApplicationDocument.ApplicationDocument = data;
                var result = await r_UpdateApplicationDocument.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
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
                r_UpdateApplicationDocument.ApplicationDocument = data;
                var result = await r_UpdateApplicationDocument.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<ApplicationDocument>(ProcessResultStatus.Failed, "Invalid application document.");
            }
        }
    }
}
