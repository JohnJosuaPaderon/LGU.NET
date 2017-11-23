using LGU.Utilities;
using System;
using System.IO;
using System.Security;

namespace LGU.Security
{
    public sealed class CryptoPasswordProvider : ICryptoPasswordProvider
    {
        public CryptoPasswordProvider()
        {
            var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "crypto.txt");

            if (!File.Exists(file))
            {
                File.WriteAllText(file, "C:\\LGU.NET\\HumanResource");
            }

            _SecurePassword = SecureStringConverter.Convert(File.ReadAllText(file));
        }

        private readonly SecureString _SecurePassword;

        public SecureString Request()
        {
            return _SecurePassword ?? throw new Exception("Request for Crypto Password denied.");
        }
    }
}
