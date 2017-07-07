using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchDepartment : IEnumerableDataProcess<Department>, IAsyncEnumerableDataProcess<Department>, ICancellableEnumerableDataProcess<Department>
    {
        string SearchKey { get; set; }
    }
}
