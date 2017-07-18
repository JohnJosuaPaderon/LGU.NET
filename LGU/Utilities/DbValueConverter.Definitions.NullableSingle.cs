using System;

namespace LGU.Utilities
{
    partial class DbValueConverter
    {
        public static float? ToNullableSingle(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableSingle);
        }

        public static float? ToNullableSingle(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableSingle);
        }
    }
}
