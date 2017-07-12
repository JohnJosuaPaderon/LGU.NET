using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetPersonById : IDataProcess<Person>
    {
        long PersonId { get; set; }
    }
}
