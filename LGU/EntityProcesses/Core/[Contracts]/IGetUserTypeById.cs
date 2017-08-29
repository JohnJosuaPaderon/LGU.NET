using LGU.Entities.Core;
using LGU.Processes;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserTypeById : IProcess<IUserType>
    {
        short UserTypeId { get; set; }
    }
}
