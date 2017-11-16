using LGU.Utilities;
using System.Security.Cryptography;

namespace LGU.Security
{
    public static class Crypto
    {
        static Crypto()
        {
            _PasswordProvider = ApplicationDomain.GetService<ICryptoPasswordProvider>();
        }

        internal const int AES_KEYSIZE = 256;
        internal const int AES_BLOCKSIZE = 128;
        internal const CipherMode AES_MODE = CipherMode.CBC;

        private static readonly ICryptoPasswordProvider _PasswordProvider;

        internal static Aes GetAes()
        {
            var aes = Aes.Create();
            aes.BlockSize = AES_BLOCKSIZE;
            aes.KeySize = AES_KEYSIZE;
            aes.Mode = AES_MODE;
            return aes;
        }

        public static string Encrypt(string text, string password, bool compressed)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            using (var encryptor = new Encryptor(text, password, compressed))
            {
                return encryptor.Execute();
            }
        }

        public static string Encrypt(string text, string password)
        {
            return Encrypt(text, password, false);
        }

        public static string Encrypt(string text)
        {
            return Encrypt(text, SecureStringConverter.Convert(_PasswordProvider.Request()));
        }

        public static string Decrypt(string text, string password, bool compressed)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            using (var decryptor = new Decryptor(text, password, compressed))
            {
                return decryptor.Execute();
            }
        }

        public static string Decrypt(string text, string password)
        {
            return Decrypt(text, password, false);
        }

        public static string Decrypt(string text)
        {
            return Decrypt(text, SecureStringConverter.Convert(_PasswordProvider.Request()));
        }
    }
}
