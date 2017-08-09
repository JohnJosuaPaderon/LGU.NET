using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : ManagerBase<Employee, long>, IEmployeeManager
    {
        private readonly IDeleteEmployee r_Delete;
        private readonly IGetEmployeeById r_GetById;
        private readonly IGetEmployeeList r_GetList;
        private readonly IInsertEmployee r_Insert;
        private readonly IUpdateEmployee r_Update;
        private readonly ISearchEmployee r_Search;
        private readonly IGetEmployeeListWithTimeLog r_GetListWithTimeLog;
        private readonly ISearchEmployeeWithTimeLog r_SearchWithTimeLog;

        public EmployeeManager(
            IDeleteEmployee delete,
            IGetEmployeeById getById,
            IGetEmployeeList getList,
            IInsertEmployee insert,
            IUpdateEmployee update,
            ISearchEmployee search,
            IGetEmployeeListWithTimeLog getListWithTimeLog,
            ISearchEmployeeWithTimeLog searchWithTimeLog)
        {
            r_Delete = delete;
            r_GetById = getById;
            r_GetList = getList;
            r_Insert = insert;
            r_Update = update;
            r_Search = search;
            r_GetListWithTimeLog = getListWithTimeLog;
            r_SearchWithTimeLog = searchWithTimeLog;
        }

        public IProcessResult<Employee> Delete(Employee data)
        {
            if (data != null)
            {
                r_Delete.Employee = data;
                return RemoveIfSuccess(r_Delete.Execute());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> DeleteAsync(Employee data)
        {
            if (data != null)
            {
                r_Delete.Employee = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> DeleteAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Delete.Employee = data;
                return RemoveIfSuccess(await r_Delete.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<Employee> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    r_GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(r_GetById.Execute());
                }
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IProcessResult<Employee>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    r_GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IProcessResult<Employee>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    r_GetById.EmployeeId = id;
                    return AddUpdateIfSuccess(await r_GetById.ExecuteAsync());
                }
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public IEnumerableProcessResult<Employee> GetList()
        {
            return AddUpdateIfSuccess(r_GetList.Execute());
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListAsync()
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListAsync(CancellationToken cancellationToken)
        {
            return AddUpdateIfSuccess(await r_GetList.ExecuteAsync(cancellationToken));
        }

        public IProcessResult<Employee> Insert(Employee data)
        {
            if (data != null)
            {
                r_Insert.Employee = data;
                return AddIfSuccess(r_Insert.Execute());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> InsertAsync(Employee data)
        {
            if (data != null)
            {
                r_Insert.Employee = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> InsertAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Insert.Employee = data;
                return AddIfSuccess(await r_Insert.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IProcessResult<Employee> Update(Employee data)
        {
            if (data != null)
            {
                r_Update.Employee = data;
                return UpdateIfSuccess(r_Update.Execute());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> UpdateAsync(Employee data)
        {
            if (data != null)
            {
                r_Update.Employee = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync());
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IProcessResult<Employee>> UpdateAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                r_Update.Employee = data;
                return UpdateIfSuccess(await r_Update.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IEnumerableProcessResult<Employee> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(r_Search.Execute());
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await r_Search.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_Search.SearchKey = searchKey;
                return AddUpdateIfSuccess(await r_Search.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public IEnumerableProcessResult<Employee> GetListWithTimeLog(ValueRange<DateTime> cutOff)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(r_GetListWithTimeLog.Execute());
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await r_GetListWithTimeLog.ExecuteAsync());
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListWithTimeLogAsync(ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            r_GetListWithTimeLog.CutOff = cutOff;
            return AddUpdateIfSuccess(await r_GetListWithTimeLog.ExecuteAsync(cancellationToken));
        }

        public IEnumerableProcessResult<Employee> SearchWithTimeLog(string searchKey, ValueRange<DateTime> cutOff)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchWithTimeLog.SearchKey = searchKey;
                r_SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(r_SearchWithTimeLog.Execute());
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchWithTimeLog.SearchKey = searchKey;
                r_SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(await r_SearchWithTimeLog.ExecuteAsync());
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Employee>> SearchWithTimeLogAsync(string searchKey, ValueRange<DateTime> cutOff, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                r_SearchWithTimeLog.SearchKey = searchKey;
                r_SearchWithTimeLog.CutOff = cutOff;
                return AddUpdateIfSuccess(await r_SearchWithTimeLog.ExecuteAsync(cancellationToken));
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
