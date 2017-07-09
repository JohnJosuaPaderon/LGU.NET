using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentManager : IDepartmentManager
    {
        private readonly IDeleteDepartment DeleteDepartment;
        private readonly IGetDepartmentById GetDepartmentById;
        private readonly IGetDepartmentList GetDepartmentList;
        private readonly IInsertDepartment InsertDepartment;
        private readonly IUpdateDepartment UpdateDepartment;
        private readonly ISearchDepartment SearchDepartment;

        private static EntityCollection<Department, int> StaticSource { get; } = new EntityCollection<Department, int>();

        public DepartmentManager(
            IDeleteDepartment deleteDepartment,
            IGetDepartmentById getDepartmentById,
            IGetDepartmentList getDepartmentList,
            IInsertDepartment insertDepartment,
            IUpdateDepartment updateDepartment,
            ISearchDepartment searchDepartment)
        {
            DeleteDepartment = deleteDepartment;
            GetDepartmentById = getDepartmentById;
            GetDepartmentList = getDepartmentList;
            InsertDepartment = insertDepartment;
            UpdateDepartment = updateDepartment;
            SearchDepartment = searchDepartment;
        }

        public IDataProcessResult<Department> Delete(Department data)
        {
            if (data != null)
            {
                DeleteDepartment.Department = data;
                var result = DeleteDepartment.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IDataProcessResult<Department>> DeleteAsync(Department data)
        {
            if (data != null)
            {
                DeleteDepartment.Department = data;
                var result = await DeleteDepartment.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IDataProcessResult<Department>> DeleteAsync(Department data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteDepartment.Department = data;
                var result = await DeleteDepartment.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Remove(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IDataProcessResult<Department> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Department>(StaticSource[id]);
                }

                GetDepartmentById.DepartmentId = id;
                var result = GetDepartmentById.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.AddUpdate(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IDataProcessResult<Department>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Department>(StaticSource[id]);
                }

                GetDepartmentById.DepartmentId = id;
                var result = await GetDepartmentById.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.AddUpdate(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IDataProcessResult<Department>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new DataProcessResult<Department>(StaticSource[id]);
                }

                GetDepartmentById.DepartmentId = id;
                var result = await GetDepartmentById.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.AddUpdate(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public IEnumerableDataProcessResult<Department> GetList()
        {
            return GetDepartmentList.Execute();
        }

        public Task<IEnumerableDataProcessResult<Department>> GetListAsync()
        {
            return GetDepartmentList.ExecuteAsync();
        }

        public Task<IEnumerableDataProcessResult<Department>> GetListAsync(CancellationToken cancellationToken)
        {
            return GetDepartmentList.ExecuteAsync(cancellationToken);
        }

        public IDataProcessResult<Department> Insert(Department data)
        {
            if (data != null)
            {
                InsertDepartment.Department = data;
                var result = InsertDepartment.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IDataProcessResult<Department>> InsertAsync(Department data)
        {
            if (data != null)
            {
                InsertDepartment.Department = data;
                var result = await InsertDepartment.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IDataProcessResult<Department>> InsertAsync(Department data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertDepartment.Department = data;
                var result = await InsertDepartment.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Add(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IDataProcessResult<Department> Update(Department data)
        {
            if (data != null)
            {
                UpdateDepartment.Department = data;
                var result = UpdateDepartment.Execute();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IDataProcessResult<Department>> UpdateAsync(Department data)
        {
            if (data != null)
            {
                UpdateDepartment.Department = data;
                var result = await UpdateDepartment.ExecuteAsync();

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IDataProcessResult<Department>> UpdateAsync(Department data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateDepartment.Department = data;
                var result = await UpdateDepartment.ExecuteAsync(cancellationToken);

                if (result.Status == ProcessResultStatus.Success)
                {
                    StaticSource.Update(result.Data);
                }

                return result;
            }
            else
            {
                return new DataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IEnumerableDataProcessResult<Department> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchDepartment.SearchKey = searchKey;
                return SearchDepartment.Execute();
            }
            else
            {
                return new EnumerableDataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableDataProcessResult<Department>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchDepartment.SearchKey = searchKey;
                return await SearchDepartment.ExecuteAsync();
            }
            else
            {
                return new EnumerableDataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableDataProcessResult<Department>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchDepartment.SearchKey = searchKey;
                return await SearchDepartment.ExecuteAsync(cancellationToken);
            }
            else
            {
                return new EnumerableDataProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
