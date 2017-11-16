using LGU.Utilities;
using System;
using System.Security;

namespace LGU.Security
{
    public sealed class CryptoPasswordProvider : ICryptoPasswordProvider
    {
        public CryptoPasswordProvider()
        {
            _SecurePassword = SecureStringConverter.Convert(Environment.CurrentDirectory);
        }

        private readonly SecureString _SecurePassword;

        public SecureString Request()
        {
            return _SecurePassword ?? throw new Exception("Request for Crypto Password denied.");
        }
    }
}
