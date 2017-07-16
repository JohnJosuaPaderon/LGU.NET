using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserStatusById : IDataProcess<UserStatus>
    {
        short UserStatusId { get; set; }
    }
}
