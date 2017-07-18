using System;

namespace LGU.Utilities
{
    partial class DbValueConverter
    {
        public static sbyte? ToNullableSByte(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableSByte);
        }

        public static sbyte? ToNullableSByte(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableSByte);
        }
    }
}
