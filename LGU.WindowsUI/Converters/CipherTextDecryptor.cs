using LGU.Security;
using LGU.Utilities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class CipherTextDecryptor : IValueConverter
    {
        static CipherTextDecryptor()
        {
            Instance = new CipherTextDecryptor();
        }

        public static CipherTextDecryptor Instance { get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cipherText = ValueConverter.ToString(value);

            return Crypto.Decrypt(cipherText);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var plainText = ValueConverter.ToString(value);
            var cipherText = Crypto.Encrypt(plainText);
            return cipherText;
        }
    }
}
