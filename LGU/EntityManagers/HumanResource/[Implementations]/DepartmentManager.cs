using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentManager : ManagerBase<Department, int>, IDepartmentManager
    {
        private readonly IDeleteDepartment r_DeleteDepartment;
        private readonly IGetDepartmentById r_GetDepartmentById;
        private readonly IGetDepartmentList r_GetDepartmentList;
        private readonly IInsertDepartment r_InsertDepartment;
        private readonly IUpdateDepartment r_UpdateDepartment;
        private readonly ISearchDepartment r_SearchDepartment;

        public DepartmentManager(
            IDeleteDepartment deleteDepartment,
            IGetDepartmentById getDepartmentById,
            IGetDepartmentList getDepartmentList,
            IInsertDepartment insertDepartment,
            IUpdateDepartment updateDepartment,
            ISearchDepartment searchDepartment)
        {
            r_DeleteDepartment = deleteDepartment;
            r_GetDepartmentById = getDepartmentById;
            r_GetDepartmentList = getDepartmentList;
            r_InsertDepartment = insertDepartment;
            r_UpdateDepartment = updateDepartment;
            r_SearchDepartment = searchDepartment;
        }

        public IProcessResult<Department> Delete(Department data)
        {
            if (data != null)
            {
                r_DeleteDepartment.Department = data;
                var result = r_DeleteDepartment.Execute();
                RemoveIfSuccess(result);

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
                r_DeleteDepartment.Department = data;
                var result = await r_DeleteDepartment.ExecuteAsync();
                RemoveIfSuccess(result);

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
                r_DeleteDepartment.Department = data;
                var result = await r_DeleteDepartment.ExecuteAsync(cancellationToken);
                RemoveIfSuccess(result);

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

                r_GetDepartmentById.DepartmentId = id;
                var result = r_GetDepartmentById.Execute();
                AddUpdateIfSuccess(result);

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

                r_GetDepartmentById.DepartmentId = id;
                var result = await r_GetDepartmentById.ExecuteAsync();
                AddUpdateIfSuccess(result);

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

                r_GetDepartmentById.DepartmentId = id;
                var result = await r_GetDepartmentById.ExecuteAsync(cancellationToken);
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new ProcessResult<Department>(ProcessResultStatus.Failed, "Invalid department identifier.");
            }
        }

        public IEnumerableProcessResult<Department> GetList()
        {
            var result = r_GetDepartmentList.Execute();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Department>> GetListAsync()
        {
            var result = await r_GetDepartmentList.ExecuteAsync();
            AddUpdateIfSuccess(result);

            return result;
        }

        public async Task<IEnumerableProcessResult<Department>> GetListAsync(CancellationToken cancellationToken)
        {
            var result = await r_GetDepartmentList.ExecuteAsync(cancellationToken);
            AddUpdateIfSuccess(result);

            return result;
        }

        public IProcessResult<Department> Insert(Department data)
        {
            if (data != null)
            {
                r_InsertDepartment.Department = data;
                var result = r_InsertDepartment.Execute();
                AddIfSuccess(result);

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
                r_InsertDepartment.Department = data;
                var result = await r_InsertDepartment.ExecuteAsync();
                AddIfSuccess(result);

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
                r_InsertDepartment.Department = data;
                var result = await r_InsertDepartment.ExecuteAsync(cancellationToken);
                AddIfSuccess(result);

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
                r_UpdateDepartment.Department = data;
                var result = r_UpdateDepartment.Execute();
                UpdateIfSuccess(result);

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
                r_UpdateDepartment.Department = data;
                var result = await r_UpdateDepartment.ExecuteAsync();
                UpdateIfSuccess(result);

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
                r_UpdateDepartment.Department = data;
                var result = await r_UpdateDepartment.ExecuteAsync(cancellationToken);
                UpdateIfSuccess(result);

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
                r_SearchDepartment.SearchKey = searchKey;
                var result = r_SearchDepartment.Execute();
                AddUpdateIfSuccess(result);

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
                r_SearchDepartment.SearchKey = searchKey;
                var result = await r_SearchDepartment.ExecuteAsync();
                AddUpdateIfSuccess(result);

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
                r_SearchDepartment.SearchKey = searchKey;
                var result = await r_SearchDepartment.ExecuteAsync(cancellationToken);
                AddUpdateIfSuccess(result);

                return result;
            }
            else
            {
                return new EnumerableProcessResult<Department>(ProcessResultStatus.Failed, "Invalid search key.");
            }
        }
    }
}
