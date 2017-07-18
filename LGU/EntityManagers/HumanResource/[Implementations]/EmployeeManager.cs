using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : ManagerBase, IEmployeeManager
    {
        private readonly IDeleteEmployee DeleteProc;
        private readonly IGetEmployeeById GetByIdProc;
        private readonly IGetEmployeeList GetListProc;
        private readonly IInsertEmployee InsertProc;
        private readonly IUpdateEmployee UpdateProc;
        private readonly ISearchEmployee SearchProc;

        private static EntityCollection<Employee, long> StaticSource { get; } = new EntityCollection<Employee, long>();

        public EmployeeManager(
            IDeleteEmployee deleteProc,
            IGetEmployeeById getByIdProc,
            IGetEmployeeList getListProc,
            IInsertEmployee insertProc,
            IUpdateEmployee updateProc,
            ISearchEmployee searchProc)
        {
            DeleteProc = deleteProc;
            GetByIdProc = getByIdProc;
            GetListProc = getListProc;
            InsertProc = insertProc;
            UpdateProc = updateProc;
            SearchProc = searchProc;
        }

        public IProcessResult<Employee> Delete(Employee data)
        {
            if (data != null)
            {
                DeleteProc.Employee = data;
                var result = DeleteProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
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
                DeleteProc.Employee = data;
                var result = await DeleteProc.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
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
                DeleteProc.Employee = data;
                var result = await DeleteProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
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

                GetByIdProc.EmployeeId = id;
                var result = GetByIdProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                return result;
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
                    GetByIdProc.EmployeeId = id;
                    var result = await GetByIdProc.ExecuteAsync();
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
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
                    GetByIdProc.EmployeeId = id;
                    var result = await GetByIdProc.ExecuteAsync(cancellationToken);
                    InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                    return result;
                }
            }
            else
            {
                return new ProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public IEnumerableProcessResult<Employee> GetList()
        {
            var result = GetListProc.Execute();
            InvokeIfSuccessAndListNotEmpty(result, e => StaticSource.AddUpdate(e));

            return result;
        }

        public async Task<IEnumerableProcessResult<Employee>> GetListAsync()
        {
            var result = await GetListProc.ExecuteAsync();
            InvokeIfSuccessAndListNotEmpty(result, e => StaticSource.AddUpdate(e));

            return result;
        }

        public Task<IEnumerableProcessResult<Employee>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }

        public IProcessResult<Employee> Insert(Employee data)
        {
            if (data != null)
            {
                InsertProc.Employee = data;
                var result = InsertProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
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
                InsertProc.Employee = data;
                var result = await InsertProc.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
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
                InsertProc.Employee = data;
                var result = await InsertProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
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
                UpdateProc.Employee = data;
                var result = UpdateProc.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
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
                UpdateProc.Employee = data;
                var result = await UpdateProc.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
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
                UpdateProc.Employee = data;
                var result = await UpdateProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
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
                SearchProc.SearchKey = searchKey;
                var result = SearchProc.Execute();
                InvokeIfSuccessAndListNotEmpty(result, e => StaticSource.AddUpdate(e));

                return result;
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
                SearchProc.SearchKey = searchKey;
                var result = await SearchProc.ExecuteAsync();
                InvokeIfSuccessAndListNotEmpty(result, e => StaticSource.AddUpdate(e));

                return result;
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
                SearchProc.SearchKey = searchKey;
                var result = await SearchProc.ExecuteAsync(cancellationToken);
                InvokeIfSuccessAndListNotEmpty(result, e => StaticSource.AddUpdate(e));

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
