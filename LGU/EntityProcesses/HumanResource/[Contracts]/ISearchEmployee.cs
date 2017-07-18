using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchEmployee : IEnumerableProcess<Employee>
    {
        string SearchKey { get; set; }
    }
}
