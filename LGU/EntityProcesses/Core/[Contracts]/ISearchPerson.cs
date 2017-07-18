using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface ISearchPerson : IEnumerableProcess<Person>
    {
        string SearchKey { get; set; }
    }
}
