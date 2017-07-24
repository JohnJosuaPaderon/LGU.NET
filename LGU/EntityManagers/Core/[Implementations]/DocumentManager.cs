using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class DocumentManager : ManagerBase<Document, long>, IDocumentManager
    {
        private readonly IDeleteDocument r_DeleteDocument;
        private readonly IGetDocumentById r_GetDocumentById;
        private readonly IGetDocumentList r_GetDocumentList;
        private readonly IInsertDocument r_InsertDocument;
        private readonly IUpdateDocument r_UpdateDocument;

        public DocumentManager(
            IDeleteDocument deleteDocument,
            IGetDocumentById getDocumentById,
            IGetDocumentList getDocumentList,
            IInsertDocument insertDocument,
            IUpdateDocument updateDocument)
        {
            r_DeleteDocument = deleteDocument;
            r_GetDocumentById = getDocumentById;
            r_GetDocumentList = getDocumentList;
            r_InsertDocument = insertDocument;
            r_UpdateDocument = updateDocument;
        }

        public IProcessResult<Document> Delete(Document data)
        {
            if (data != null)
            {
                r_DeleteDocument.Document = data;
                var result = r_DeleteDocument.Execute();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public async Task<IProcessResult<Document>> DeleteAsync(Document data)
        {
            if (data != null)
            {
                r_DeleteDocument.Document = data;
                var result = await r_DeleteDocument.ExecuteAsync();
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public async Task<IProcessResult<Document>> DeleteAsync(Document data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_DeleteDocument.Document = data;
                var result = await r_DeleteDocument.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public IProcessResult<Document> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Document>(StaticSource[id]);
                }

                r_GetDocumentById.DocumentId = id;
                var result = r_GetDocumentById.Execute();
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document identifier.");
            }
        }

        public async Task<IProcessResult<Document>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Document>(StaticSource[id]);
                }

                r_GetDocumentById.DocumentId = id;
                var result = await r_GetDocumentById.ExecuteAsync();
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document identifier.");
            }
        }

        public async Task<IProcessResult<Document>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Document>(StaticSource[id]);
                }

                r_GetDocumentById.DocumentId = id;
                var result = await r_GetDocumentById.ExecuteAsync(cancellationToken);
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document identifier.");
            }
        }

        public IEnumerableProcessResult<Document> GetList()
        {
            var result = r_GetDocumentList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Document>> GetListAsync()
        {
            var result = await r_GetDocumentList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Document>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetDocumentList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Document> Insert(Document data)
        {
            if (data != null)
            {
                r_InsertDocument.Document = data;
                var result = r_InsertDocument.Execute();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public async Task<IProcessResult<Document>> InsertAsync(Document data)
        {
            if (data != null)
            {
                r_InsertDocument.Document = data;
                var result = await r_InsertDocument.ExecuteAsync();
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public async Task<IProcessResult<Document>> InsertAsync(Document data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_InsertDocument.Document = data;
                var result = await r_InsertDocument.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public IProcessResult<Document> Update(Document data)
        {
            if (data != null)
            {
                r_UpdateDocument.Document = data;
                var result = r_UpdateDocument.Execute();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public async Task<IProcessResult<Document>> UpdateAsync(Document data)
        {
            if (data != null)
            {
                r_UpdateDocument.Document = data;
                var result = await r_UpdateDocument.ExecuteAsync();
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }

        public async Task<IProcessResult<Document>> UpdateAsync(Document data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_UpdateDocument.Document = data;
                var result = await r_UpdateDocument.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Document>(ProcessResultStatus.Failed, "Invalid document.");
            }
        }
    }
}
