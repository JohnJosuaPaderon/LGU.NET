using LGU.Entities.Core;
using LGU.EntityProcesses.Core;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.Core
{
    public sealed class DocumentPathTypeManager : ManagerBase<IDocumentPathType, short>, IDocumentPathTypeManager
    {
        private readonly IGetDocumentPathTypeById r_GetDocumentPathTypeById;
        private readonly IGetDocumentPathTypeList r_GetDocumentPathTypeList;

        public DocumentPathTypeManager(
            IGetDocumentPathTypeById getDocumentPathTypeById,
            IGetDocumentPathTypeList getDocumentPathTypeList)
        {
            r_GetDocumentPathTypeById = getDocumentPathTypeById;
            r_GetDocumentPathTypeList = getDocumentPathTypeList;
        }

        public IProcessResult<IDocumentPathType> GetById(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDocumentPathType>(StaticSource[id]);
                }
                else
                {
                    r_GetDocumentPathTypeById.DocumentPathTypeId = id;
                    var result = r_GetDocumentPathTypeById.Execute();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IDocumentPathType>(ProcessResultStatus.Failed, "Invalid document path type identifier.");
            }
        }

        public async Task<IProcessResult<IDocumentPathType>> GetByIdAsync(short id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDocumentPathType>(StaticSource[id]);
                }
                else
                {
                    r_GetDocumentPathTypeById.DocumentPathTypeId = id;
                    var result = await r_GetDocumentPathTypeById.ExecuteAsync();
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IDocumentPathType>(ProcessResultStatus.Failed, "Invalid document path type identifier.");
            }
        }

        public async Task<IProcessResult<IDocumentPathType>> GetByIdAsync(short id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDocumentPathType>(StaticSource[id]);
                }
                else
                {
                    r_GetDocumentPathTypeById.DocumentPathTypeId = id;
                    var result = await r_GetDocumentPathTypeById.ExecuteAsync(cancellationToken);
                    AddUpdateIfSuccess(result);

                    return result;
                }
            }
            else
            {
                return new ProcessResult<IDocumentPathType>(ProcessResultStatus.Failed, "Invalid document path type identifier.");
            }
        }

        public IEnumerableProcessResult<IDocumentPathType> GetList()
        {
            var result = r_GetDocumentPathTypeList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IDocumentPathType>> GetListAsync()
        {
            var result = await r_GetDocumentPathTypeList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<IDocumentPathType>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetDocumentPathTypeList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }
    }
}
