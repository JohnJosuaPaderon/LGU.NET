using LGU.Core.Entities;

namespace LGU.Core.EntityProcesses
{
    public interface IInsertComputer : IProcess<Computer>
    {
        Computer Computer { get; }
    }
}
