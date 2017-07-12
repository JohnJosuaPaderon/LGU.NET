using System.Collections.Generic;
using System.Security;

namespace LGU
{
    public interface IConnectionStringSource
    {
        bool IsEncrypted { get; }
        SecureString this[string key] { get; }
        IEnumerable<ConnectionString> GetSource();
        void Overwrite(bool isEncrypted, IEnumerable<ConnectionString> connectionStrings);
    }
}
