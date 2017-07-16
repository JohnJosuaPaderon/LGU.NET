using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface IGetUserTypeById : IDataProcess<UserType>
    {
        short UserTypeId { get; set; }
    }
}
