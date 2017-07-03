using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IConstructPersonInformalFullName : IDataProcess<string>
    {
        Person Person { get; set; }
    }
}
