using System.Security;

namespace LGU.Security
{
    public interface ICryptoPasswordProvider
    {
        SecureString Request();
    }
}
