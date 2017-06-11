using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    public interface IConstructPersonInformalFullName : IProcess<string>
    {
        Person Person { get; }
    }
}
