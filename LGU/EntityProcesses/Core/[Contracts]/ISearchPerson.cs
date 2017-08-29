using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface ISearchPerson : IEnumerableProcess<IPerson>
    {
        string SearchKey { get; set; }
    }
}
