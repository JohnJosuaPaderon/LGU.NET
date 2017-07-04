using System;
using System.Threading;
using System.Threading.Tasks;
using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public sealed class GetDepartmentList : IGetDepartmentList
    {
        public IEnumerableDataProcessResult<Department> Execute()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableDataProcessResult<Department>> ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerableDataProcessResult<Department>> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
