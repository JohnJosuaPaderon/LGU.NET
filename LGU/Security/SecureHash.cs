using System;
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

        public static string ComputeSHA512(string value)
        {
            return ComputeHash(value, SHA512.Create());
        }
    }
}
