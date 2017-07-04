using System;
using System.Threading;
using System.Threading.Tasks;
using LGU.Entities.HumanResource;
using LGU.EntityProcesses.HumanResource;

namespace LGU.EntityManagers.HumanResource
{
    public sealed class DepartmentManager : IDepartmentManager
    {
        public DepartmentManager(IDeleteDepartment deleteDepartment, IGetDepartmentById getDepartmentById, IGetDepartmentList getDepartmentList, IInsertDepartment insertDepartment, IUpdateDepartment updateDepartment)
        {

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
    }
}
