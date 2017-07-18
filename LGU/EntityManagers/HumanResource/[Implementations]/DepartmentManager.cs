using LGU.Entities;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentManager : ManagerBase, IDepartmentManager
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

        public IProcessResult<Department> Delete(Department data)
        {
            if (data != null)
            {
                DeleteDepartment.Department = data;
                var result = DeleteDepartment.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<Department>> DeleteAsync(Department data)
        {
            if (data != null)
            {
                DeleteDepartment.Department = data;
                var result = await DeleteDepartment.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<Department>> DeleteAsync(Department data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                DeleteDepartment.Department = data;
                var result = await DeleteDepartment.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Remove(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IProcessResult<Department> GetById(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Department>(StaticSource[id]);
                }

                GetDepartmentById.DepartmentId = id;
                var result = GetDepartmentById.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IProcessResult<Department>> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Department>(StaticSource[id]);
                }

                GetDepartmentById.DepartmentId = id;
                var result = await GetDepartmentById.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public async Task<IProcessResult<Department>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id > 0)
            {
                if (StaticSource.ContainsId(id))
                {
                    return new ProcessResult<Department>(StaticSource[id]);
                }

                GetDepartmentById.DepartmentId = id;
                var result = await GetDepartmentById.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.AddUpdate(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public IEnumerableProcessResult<Department> GetList()
        {
            var result = GetDepartmentList.Execute();
            InvokeIfSuccessAndListNotEmpty(result, d => StaticSource.AddUpdate(d));

            return result;
        }

        public async Task<IEnumerableProcessResult<Department>> GetListAsync()
        {
            var result = await GetDepartmentList.ExecuteAsync();
            InvokeIfSuccessAndListNotEmpty(result, d => StaticSource.AddUpdate(d));

            return result;
        }

        public async Task<IEnumerableProcessResult<Department>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await GetDepartmentList.ExecuteAsync(cancellationToken);
            InvokeIfSuccessAndListNotEmpty(result, d => StaticSource.AddUpdate(d));

            return result;
        }

        public IProcessResult<Department> Insert(Department data)
        {
            if (data != null)
            {
                InsertDepartment.Department = data;
                var result = InsertDepartment.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<Department>> InsertAsync(Department data)
        {
            if (data != null)
            {
                InsertDepartment.Department = data;
                var result = await InsertDepartment.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<Department>> InsertAsync(Department data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                InsertDepartment.Department = data;
                var result = await InsertDepartment.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Add(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IProcessResult<Department> Update(Department data)
        {
            if (data != null)
            {
                UpdateDepartment.Department = data;
                var result = UpdateDepartment.Execute();
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<Department>> UpdateAsync(Department data)
        {
            if (data != null)
            {
                UpdateDepartment.Department = data;
                var result = await UpdateDepartment.ExecuteAsync();
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public async Task<IProcessResult<Department>> UpdateAsync(Department data, CancellationToken cancellationToken)
        {
            if (data != null)
            {
                UpdateDepartment.Department = data;
                var result = await UpdateDepartment.ExecuteAsync(cancellationToken);
                InvokeIfSuccess(result.Status, () => StaticSource.Update(result.Data));

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department.");
            }
        }

        public IEnumerableProcessResult<Department> Search(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchDepartment.SearchKey = searchKey;
                var result = SearchDepartment.Execute();
                InvokeIfSuccessAndListNotEmpty(result, d => StaticSource.AddUpdate(d));

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Department>> SearchAsync(string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchDepartment.SearchKey = searchKey;
                var result = await SearchDepartment.ExecuteAsync();
                InvokeIfSuccessAndListNotEmpty(result, d => StaticSource.AddUpdate(d));

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }

        public async Task<IEnumerableProcessResult<Department>> SearchAsync(string searchKey, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                SearchDepartment.SearchKey = searchKey;
                var result = await SearchDepartment.ExecuteAsync(cancellationToken);
                InvokeIfSuccessAndListNotEmpty(result, d => StaticSource.AddUpdate(d));

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
