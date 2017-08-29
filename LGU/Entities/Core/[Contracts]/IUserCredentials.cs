using System.Security;

namespace LGU.Entities.Core
{
    public interface IUserCredentials
    {
        SecureString SecureUsername { get; set; }
        SecureString SecurePassword { get; set; }
    }
}
