using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentManager : EntityManagerBase<IDepartment, int>, IDepartmentManager
    {
        private readonly IDeleteDepartment r_Delete;
        private readonly IGetDepartmentById r_GetById;
        private readonly IGetDepartmentList r_GetList;
        private readonly IInsertDepartment r_Insert;
        private readonly IUpdateDepartment r_Update;
        private readonly ISearchDepartment r_Search;
        private readonly IGetDepartmentListWithTimeLog r_GetListWithTimeLog;

        public DepartmentManager(
            IDeleteDepartment delete,
            IGetDepartmentById getById,
            IGetDepartmentList getList,
            IInsertDepartment insert,
            IUpdateDepartment update,
            ISearchDepartment search,
            IGetDepartmentListWithTimeLog getListWithTimeLog)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
            r_Search = search;
            r_GetListWithTimeLog = getListWithTimeLog;
        }

        public IProcessResult<IDepartment> Delete(IDepartment data)
        {
            if (data != null)
            {
                r_Delete.Department = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> DeleteAsync(IDepartment data)
        {
            if (data != null)
            {
                r_Delete.Department = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> DeleteAsync(IDepartment data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.Department = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IProcessResult<IDepartment> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartment>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute()); 
                }
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IProcessResult<IDepartment>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartment>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IProcessResult<IDepartment>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IDepartment>(StaticSource[id]);
                }
                else
                {
                    r_GetById.DepartmentId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync(cancellationToken));
                }
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public IEnumerableProcessResult<IDepartment> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IDepartment> Insert(IDepartment data)
        {
            if (data != null)
            {
                r_Insert.Department = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> InsertAsync(IDepartment data)
        {
            if (data != null)
            {
                r_Insert.Department = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> InsertAsync(IDepartment data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.Department = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IProcessResult<IDepartment> Update(IDepartment data)
        {
            if (data != null)
            {
                r_Update.Department = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> UpdateAsync(IDepartment data)
        {
            if (data != null)
            {
                r_Update.Department = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<IDepartment>> UpdateAsync(IDepartment data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.Department = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IEnumerableProcessResult<IDepartment> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(r_Search.Execute());
            }
            else
            {
                return new EnumerableProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await r_Search.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IDepartment>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await r_Search.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<IDepartment>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public IEnumerableProcessResult<IDepartment> GetListWithTimeLog(ValueRange<DateTime> cutOff)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(r_GetListWithTimeLog.Execute());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await r_GetListWithTimeLog.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IDepartment>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await r_GetListWithTimeLog.ExecuteAsync(cancellationToken));
        }
    }
}
