using System;

namespace LGU.Utilities
{
    partial class DbValueConverter
    {
        public static decimal? ToNullableDecimal(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableDecimal);
        }

        public static decimal? ToNullableDecimal(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableDecimal);
        }
    }
}
