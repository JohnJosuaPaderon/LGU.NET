using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IInsertPerson : IDataProcess<Person>
    {
        Person Person { get; set; }
    }
}
