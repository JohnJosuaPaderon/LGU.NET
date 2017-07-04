using System.Security;

namespace LGU
{
    public interface IConnectionStringSource
    {
        SecureString Core { get; }
        SecureString HumanResource { get; }
    }
}
