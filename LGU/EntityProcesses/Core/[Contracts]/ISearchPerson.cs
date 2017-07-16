using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface ISearchPerson : IEnumerableDataProcess<Person>
    {
        string SearchKey { get; set; }
    }
}
