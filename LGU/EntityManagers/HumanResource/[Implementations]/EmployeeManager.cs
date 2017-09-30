using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : EntityManagerBase<IEmployee, long>, IEmployeeManager
    {
        private readonly IDeleteEmployee r_Delete;
        private readonly IGetEmployeeById r_GetById;
        private readonly IGetEmployeeList r_GetList;
        private readonly IInsertEmployee r_Insert;
        private readonly IUpdateEmployee r_Update;
        private readonly ISearchEmployee r_Search;
        private readonly IGetEmployeeListWithTimeLog r_GetListWithTimeLog;
        private readonly ISearchEmployeeWithTimeLog r_SearchWithTimeLog;
        private readonly IGetEmployeeListWithTimeLogByDepartment r_GetListWithTimeLogByDepartment;

        public EmployeeManager(
            IDeleteEmployee delete,
            IGetEmployeeById getById,
            IGetEmployeeList getList,
            IInsertEmployee insert,
            IUpdateEmployee update,
            ISearchEmployee search,
            IGetEmployeeListWithTimeLog getListWithTimeLog,
            ISearchEmployeeWithTimeLog searchWithTimeLog,
            IGetEmployeeListWithTimeLogByDepartment getListWithTimeLogByDepartment)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
            r_Search = search;
            r_GetListWithTimeLog = getListWithTimeLog;
            r_SearchWithTimeLog = searchWithTimeLog;
            r_GetListWithTimeLogByDepartment = getListWithTimeLogByDepartment;
        }

        public IProcessResult<IEmployee> Delete(IEmployee data)
        {
            if (data != null)
            {
                r_Delete.Employee = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<IEmployee>> DeleteAsync(IEmployee data)
        {
            if (data != null)
            {
                r_Delete.Employee = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<IEmployee>> DeleteAsync(IEmployee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.Employee = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<IEmployee> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployee>(StaticSource[id]);
                }
                else
                {
                    r_GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IProcessResult<IEmployee>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployee>(StaticSource[id]);
                }
                else
                {
                    r_GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IProcessResult<IEmployee>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<IEmployee>(StaticSource[id]);
                }
                else
                {
                    r_GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public IEnumerableProcessResult<IEmployee> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<IEmployee> Insert(IEmployee data)
        {
            if (data != null)
            {
                r_Insert.Employee = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<IEmployee>> InsertAsync(IEmployee data)
        {
            if (data != null)
            {
                r_Insert.Employee = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<IEmployee>> InsertAsync(IEmployee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.Employee = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<IEmployee> Update(IEmployee data)
        {
            if (data != null)
            {
                r_Update.Employee = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<IEmployee>> UpdateAsync(IEmployee data)
        {
            if (data != null)
            {
                r_Update.Employee = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<IEmployee>> UpdateAsync(IEmployee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.Employee = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IEnumerableProcessResult<IEmployee> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(r_Search.Execute());
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await r_Search.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await r_Search.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public IEnumerableProcessResult<IEmployee> GetListWithTimeLog(ValueRange<DateTime> cutOff)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(r_GetListWithTimeLog.Execute());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await r_GetListWithTimeLog.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await r_GetListWithTimeLog.ExecuteAsync(cancellationToken));
        }

        public IEnumerableProcessResult<IEmployee> SearchWithTimeLog(string searchKey, ValueRange<DateTime> cutOff)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchWithTimeLog.SearchKey = searchKey;
                r_SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(r_SearchWithTimeLog.Execute());
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchWithTimeLog.SearchKey = searchKey;
                r_SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(await r_SearchWithTimeLog.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchWithTimeLog.SearchKey = searchKey;
                r_SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(await r_SearchWithTimeLog.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public IEnumerableProcessResult<IEmployee> GetListWithTimeLogByDepartment(ValueRange<DateTime> cutOff, IDepartment department)
        {
            if (department != null)
            {
                r_GetListWithTimeLogByDepartment.CutOff = cutOff;
                r_GetListWithTimeLogByDepartment.Department = department;
                return AddUpdateIfSuccess(r_GetListWithTimeLogByDepartment.Execute());
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogByDepartmentAsync(ValueRange<DateTime> cutOff, IDepartment department)
        {
            if (department != null)
            {
                r_GetListWithTimeLogByDepartment.CutOff = cutOff;
                r_GetListWithTimeLogByDepartment.Department = department;
                return AddUpdateIfSuccess(await r_GetListWithTimeLogByDepartment.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IEnumerableProcessResult<IEmployee>> GetListWithTimeLogByDepartmentAsync(ValueRange<DateTime> cutOff, IDepartment department, CancellationToken cancellationToken)
        {
            if (department != null)
            {
                r_GetListWithTimeLogByDepartment.CutOff = cutOff;
                r_GetListWithTimeLogByDepartment.Department = department;
                return AddUpdateIfSuccess(await r_GetListWithTimeLogByDepartment.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<IEmployee>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }
    }
}
