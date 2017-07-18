using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchDepartment : IEnumerableProcess<Department>
    {
        string SearchKey { get; set; }
    }
}
