using System;
using System.Security.Cryptography;
using System.Text;

namespace LGU.Data.Utilities
{
    public static class SecureHash
    {
        private static string TransformHash(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        private static string ComputeHash(string value, HashAlgorithm algorithm)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            using (algorithm)
            {
                var data = Encoding.UTF8.GetBytes(value);
                var hash = algorithm.ComputeHash(data);
                return TransformHash(hash);
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
