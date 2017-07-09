using LGU.Entities.HumanResource;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchDepartment : IEnumerableDataProcess<Department>
    {
        string SearchKey { get; set; }
    }
}
