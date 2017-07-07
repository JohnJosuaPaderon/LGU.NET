using System;
using System.Threading;
using System.Threading.Tasks;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;
using LGU.Entities;

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

        private static EntityCollection<Department, uint> StaticSource { get; } = new EntityCollection<Department, uint>();

        public DepartmentManager(IDeleteDepartment deleteDepartment, IGetDepartmentById getDepartmentById, IGetDepartmentList getDepartmentList, IInsertDepartment insertDepartment, IUpdateDepartment updateDepartment, ISearchDepartment searchDepartment)
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
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> DeleteAsync(Department data)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> DeleteAsync(Department data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IDataProcessResult<Department> GetById(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> GetByIdAsync(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> GetByIdAsync(uint id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IEnumerableDataProcessResult<Department> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableDataProcessResult<Department>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableDataProcessResult<Department>> GetListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IDataProcessResult<Department> Insert(Department data)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> InsertAsync(Department data)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> InsertAsync(Department data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IDataProcessResult<Department> Update(Department data)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> UpdateAsync(Department data)
        {
            throw new NotImplementedException();
        }

        public Task<IDataProcessResult<Department>> UpdateAsync(Department data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
