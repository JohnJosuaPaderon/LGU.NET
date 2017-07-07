using LGU.Utilities;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LGU.Security
{
    internal sealed class Encryptor : IDisposable
    {
        #region Constructor
        public Encryptor(string text, string password, bool compressed)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Cannot be null or whitespace.", nameof(password));
            }

            B_Password = Encoding.UTF8.GetBytes(password);
            B_Text = Encoding.UTF8.GetBytes(text);
            B_PasswordHash = SHA256.Create().ComputeHash(B_Password);
            B_Salt = RandomBytes.Get();

            if (compressed)
            {
                B_Text = Compressor.Compress(B_Text);
            }

        }
        #endregion

        #region Properties
        private byte[] B_Password { get; set; }
        private byte[] B_PasswordHash { get; set; }
        private byte[] B_Text { get; set; }
        private byte[] B_Salt { get; set; }
        private byte[] B_Encrypted { get; set; }
        #endregion

        #region Methods
        public string Execute()
        {
            B_Encrypted = new byte[B_Salt.Length + B_Text.Length];

            for (int i = 0; i < B_Salt.Length; i++)
            {
                B_Encrypted[i] = B_Salt[i];
            }

            for (int i = 0; i < B_Text.Length; i++)
            {
                B_Encrypted[i + B_Salt.Length] = B_Text[i];
            }

            AesEncrypt();

            return Convert.ToBase64String(B_Encrypted);
        }

        private void AesEncrypt()
        {
            byte[] b_EncryptionResult = null;
            var b_Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (var memoryStream = new MemoryStream())
            {
                using (var rijndaelManaged = Crypto.GetAes())
                {
                    var key = new Rfc2898DeriveBytes(B_PasswordHash, b_Salt, 1000);
                    rijndaelManaged.Key = key.GetBytes(rijndaelManaged.KeySize / 8);
                    rijndaelManaged.IV = key.GetBytes(rijndaelManaged.BlockSize / 8);

                    using (var cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(B_Encrypted, 0, B_Encrypted.Length);
                    }

                    b_EncryptionResult = memoryStream.ToArray();
                }
            }

            B_Encrypted = b_EncryptionResult;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            B_Password = null;
            B_PasswordHash = null;
            B_Salt = null;
            B_Text = null;
            B_Encrypted = null;
        }
        #endregion
    }
}
