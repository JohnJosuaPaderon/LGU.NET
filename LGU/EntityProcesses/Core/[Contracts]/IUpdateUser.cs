using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IUpdateUser : IProcess<IUser>
    {
        IUser User { get; set; }
    }
}
