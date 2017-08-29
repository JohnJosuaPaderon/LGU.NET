using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserStatusById : IProcess<IUserStatus>
    {
        short UserStatusId { get; set; }
    }
}
