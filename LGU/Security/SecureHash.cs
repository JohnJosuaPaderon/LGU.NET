using LGU.Utilities;
using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace LGU.Security
{
    public static class SecureHash
    {
        private static string ComputeHash(string value, HashAlgorithm algorithm)
        {
            using (algorithm)
            {
                var computedHash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
                return BitConverter.ToString(computedHash).Replace("-", string.Empty);
            }
        }

        public static string ComputeSHA256(string value)
        {
            return ComputeHash(value, SHA256.Create());
        }

        public static string ComputeSHA256(SecureString secureValue)
        {
            return ComputeSHA256(SecureStringConverter.Convert(secureValue));
        }

        public static string ComputeSHA512(string value)
        {
            return ComputeHash(value, SHA512.Create());
        }

        public static string ComputeSHA512(SecureString secureValue)
        {
            return ComputeSHA512(SecureStringConverter.Convert(secureValue));
        }
    }
}
