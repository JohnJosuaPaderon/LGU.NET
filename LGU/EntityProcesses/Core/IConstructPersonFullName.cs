using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IConstructPersonFullName : IDataProcess<string>
    {
        Person Person { get; set; }
    }
}
