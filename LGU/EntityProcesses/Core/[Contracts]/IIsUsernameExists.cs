using LGU.Processes;
using System.Security;

namespace LGU.EntityProcesses.Core
{
    public interface IIsUsernameExists : IProcess<bool>
    {
        SecureString SecureUsername { get; set; }
    }
}
