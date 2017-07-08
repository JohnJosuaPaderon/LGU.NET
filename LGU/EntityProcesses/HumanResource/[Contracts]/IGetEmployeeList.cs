using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface IGetEmployeeList : IEnumerableDataProcess<Employee>, IAsyncEnumerableDataProcess<Employee>, ICancellableEnumerableDataProcess<Employee>
    {
    }
}
