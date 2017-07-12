using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IDeletePerson : IDataProcess<Person>
    {
        Person Person { get; set; }
    }
}
