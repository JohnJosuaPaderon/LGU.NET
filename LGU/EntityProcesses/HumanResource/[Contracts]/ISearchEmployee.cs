using LGU.Entities.HumanResource;
using LGU.Processes;

namespace LGU.EntityProcesses.HumanResource
{
    public interface ISearchEmployee : IEnumerableProcess<IEmployee>
    {
        string SearchKey { get; set; }
    }
}
