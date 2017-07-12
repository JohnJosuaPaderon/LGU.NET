using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdatePerson : IDataProcess<Person>
    {
        Person Person { get; set; }
    }
}
