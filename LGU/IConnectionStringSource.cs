using System.Security;

namespace LGU
{
    public interface IConnectionStringSource
    {
        SecureString this[string key] { get; }
    }
}
