using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class EmployeeManager : IEmployeeManager
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

        public IDataProcessResult<Employee> Delete(Employee data)
        {
            if (data != null)
            {
                DeleteProc.Employee = data;
                var result = DeleteProc.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> DeleteAsync(Employee data)
        {
            if (data != null)
            {
                DeleteProc.Employee = data;
                var result = await DeleteProc.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> DeleteAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteProc.Employee = data;
                var result = await DeleteProc.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IDataProcessResult<Employee> GetById(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Employee>(StaticSource[id]);
                }

                GetByIdProc.EmployeeId = id;
                var result = GetByIdProc.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.AddUpdate(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IDataProcessResult<Employee>> GetByIdAsync(long id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.EmployeeId = id;
                    var result = await GetByIdProc.ExecuteAsync();

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public async Task<IDataProcessResult<Employee>> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Employee>(StaticSource[id]);
                }
                else
                {
                    GetByIdProc.EmployeeId = id;
                    var result = await GetByIdProc.ExecuteAsync(cancellationToken);

                    if (result.Status == ProcessResultStatus.Success)
                    {
                        StaticSource.AddUpdate(result.Data);
                    }

                    return result;
                }
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee identifier.");
            }
        }

        public IEnumerableDataProcessResult<Employee> GetList()
        {
            return GetListProc.Execute();
        }

        public Task<IEnumerableDataProcessResult<Employee>> GetListAsync()
        {
            return GetListProc.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<Employee>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetListProc.ExecuteAsync(cancellationToken);
        }

        public IDataProcessResult<Employee> Insert(Employee data)
        {
            if (data != null)
            {
                InsertProc.Employee = data;
                var result = InsertProc.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> InsertAsync(Employee data)
        {
            if (data != null)
            {
                InsertProc.Employee = data;
                var result = await InsertProc.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> InsertAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertProc.Employee = data;
                var result = await InsertProc.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IDataProcessResult<Employee> Update(Employee data)
        {
            if (data != null)
            {
                UpdateProc.Employee = data;
                var result = UpdateProc.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> UpdateAsync(Employee data)
        {
            if (data != null)
            {
                UpdateProc.Employee = data;
                var result = await UpdateProc.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public async Task<IDataProcessResult<Employee>> UpdateAsync(Employee data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateProc.Employee = data;
                var result = await UpdateProc.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid employee.");
            }
        }

        public IEnumerableDataProcessResult<Employee> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchProc.SearchKey = searchKey;
                return SearchProc.Execute();
            }
            else
            {
                return new EnumerableDataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableDataProcessResult<Employee>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchProc.SearchKey = searchKey;
                return await SearchProc.ExecuteAsync();
            }
            else
            {
                return new EnumerableDataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableDataProcessResult<Employee>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchProc.SearchKey = searchKey;
                return await SearchProc.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new EnumerableDataProcessResult<Employee>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
