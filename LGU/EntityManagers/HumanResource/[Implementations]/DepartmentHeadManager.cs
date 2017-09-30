using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentHeadManager : EntityManagerBase<IDepartmentHead, long>, IDepartmentHeadManager
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

        public IProcessResult<IDepartmentHead> Delete(IDepartmentHead data)
        {
            if (data != null)
            {
                r_Delete.DepartmentHead = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> DeleteAsync(IDepartmentHead data)
        {
            if (data != null)
            {
                r_Delete.DepartmentHead = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> DeleteAsync(IDepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.DepartmentHead = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public IProcessResult<IDepartmentHead> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartmentHead>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head identifier.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartmentHead>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head identifier.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartmentHead>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentHeadId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head identifier.");
            }
        }

        public IEnumerableProcessResult<IDepartmentHead> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IDepartmentHead>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IDepartmentHead>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IDepartmentHead> Insert(IDepartmentHead data)
        {
            if (data != null)
            {
                r_Insert.DepartmentHead = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> InsertAsync(IDepartmentHead data)
        {
            if (data != null)
            {
                r_Insert.DepartmentHead = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> InsertAsync(IDepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.DepartmentHead = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public IProcessResult<IDepartmentHead> Update(IDepartmentHead data)
        {
            if (data != null)
            {
                r_Update.DepartmentHead = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> UpdateAsync(IDepartmentHead data)
        {
            if (data != null)
            {
                r_Update.DepartmentHead = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }

        public async Task<IProcessResult<IDepartmentHead>> UpdateAsync(IDepartmentHead data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.DepartmentHead = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartmentHead>(ProcessResultStatus.Failed, "Invalid department head.");
            }
        }
    }
}
