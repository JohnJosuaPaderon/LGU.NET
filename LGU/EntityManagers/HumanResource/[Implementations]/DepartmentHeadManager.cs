using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentHeadManager : ManagerBase<DepartmentHead, long>, IDepartmentHeadManager
    {
        private readonly IDeleteDepartmentHead r_Delete;
        private readonly IGetDepartmentHeadById r_GetById;
        private readonly IGetDepartmentHeadList r_GetList;
        private readonly IInsertDepartmentHead r_Insert;
        private readonly IUpdateDepartmentHead r_Update;

        public DepartmentHeadManager(
            IDeleteDepartmentHead delete,
            IGetDepartmentHeadById getById,
            IGetDepartmentHeadList getList,
            IInsertDepartmentHead insert,
            IUpdateDepartmentHead update)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
        }

        public IProcessResult<DepartmentHead> Delete(DepartmentHead data)
        {
            if (data != null)
            {
                r_Delete.DepartmentHead = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> DeleteAsync(DepartmentHead data)
        {
            if (data != null)
            {
                r_Delete.DepartmentHead = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> DeleteAsync(DepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.DepartmentHead = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public IProcessResult<DepartmentHead> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<DepartmentHead>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head identifier.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<DepartmentHead>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head identifier.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<DepartmentHead>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head identifier.");
            }
        }

        public IEnumerableProcessResult<DepartmentHead> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<DepartmentHead>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<DepartmentHead>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<DepartmentHead> Insert(DepartmentHead data)
        {
            if (data != null)
            {
                r_Insert.DepartmentHead = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> InsertAsync(DepartmentHead data)
        {
            if (data != null)
            {
                r_Insert.DepartmentHead = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> InsertAsync(DepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.DepartmentHead = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public IProcessResult<DepartmentHead> Update(DepartmentHead data)
        {
            if (data != null)
            {
                r_Update.DepartmentHead = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> UpdateAsync(DepartmentHead data)
        {
            if (data != null)
            {
                r_Update.DepartmentHead = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<DepartmentHead>> UpdateAsync(DepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.DepartmentHead = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<DepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }
    }
}
