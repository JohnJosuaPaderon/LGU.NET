using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface ILoginUser : IProcess<IUser>
    {
        IUserCredentials UserCredentials { get; set; }
    }
}