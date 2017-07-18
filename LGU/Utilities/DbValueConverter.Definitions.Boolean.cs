using System;

namespace LGU.Utilities
{
    partial class DbValueConverter
    {
        public static bool ToBoolean(object value)
        {
            return ConversionBase(value, ValueConverter.ToBoolean);
        }

        public static bool ToBoolean(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToBoolean);
        }
    }
}
