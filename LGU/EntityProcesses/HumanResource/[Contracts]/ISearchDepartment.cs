using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchDepartment : IEnumerableProcess<IDepartment>
    {
        string SearchKey { get; set; }
    }
}
