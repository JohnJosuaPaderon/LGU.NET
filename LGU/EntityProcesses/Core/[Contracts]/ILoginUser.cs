using LGU.Entities.Core;

namespace LGU.EntityProcesses.Core
{
    public interface ILoginUser : IDataProcess<User>
    {
        UserCredentials UserCredentials { get; set; }
    }
}