using System;

namespace LGU.Utilities
{
    partial class DbValueConverter
    {
        public static uint? ToNullableUInt32(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableUInt32);
        }

        public static uint? ToNullableUInt32(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableUInt32);
        }
    }
}
