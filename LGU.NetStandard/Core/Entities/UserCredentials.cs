using System.Security;

namespace LGU.Core.Entities
{
    public struct UserCredentials
    {
        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
    }
}
