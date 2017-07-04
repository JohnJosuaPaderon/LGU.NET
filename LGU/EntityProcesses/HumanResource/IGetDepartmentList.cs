using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetDepartmentList : IEnumerableDataProcess<Department>, IAsyncEnumerableDataProcess<Department>, ICancellableEnumerableDataProcess<Department>
    {
    }
}
