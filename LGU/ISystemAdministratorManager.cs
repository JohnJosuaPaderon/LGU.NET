using LGU.Processes;
using System.Security;

namespace LGU
{
    public interface ISystemAdministratorManager
    {
        IProcessResult Verify(SecureString secureAdministratorKey);
        void GenerateAdministratorKey();
    }
}
