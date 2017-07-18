using System;

namespace LGU.Utilities
{
    partial class DbValueConverter
    {
        public static byte? ToNullableByte(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableByte);
        }

        public static byte? ToNullableByte(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableByte);
        }
    }
}
