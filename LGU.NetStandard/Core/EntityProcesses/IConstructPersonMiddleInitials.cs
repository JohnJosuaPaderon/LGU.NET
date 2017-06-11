using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    public interface IConstructPersonMiddleInitials : IProcess<string>
    {
        Person Person { get; }
    }
}
