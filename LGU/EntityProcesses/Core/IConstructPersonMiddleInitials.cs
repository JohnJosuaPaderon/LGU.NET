using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IConstructPersonMiddleInitials : IDataProcess<string>
    {
        Person Person { get; set; }
    }
}
