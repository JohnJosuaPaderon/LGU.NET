using System;

namespace LGU.Data.Utilities
{
    public static partial class DbValueConverter
    {
        private static bool Convertible<TArgument>(TArgument value)
        {
            return !DBNull.Value.Equals(value);
        }

        private static TResult ConversionBase<TArgument, TResult>(TArgument value, Func<TArgument, TResult> converter)
        {
            return Convertible(value) ? converter(value) : default(TResult);
        }

        private static TResult ConversionBase<TArgument, TResult>(TArgument value, int fromToBase, Func<TArgument, int, TResult> converter)
        {
            return Convertible(value) ? converter(value, fromToBase) : default(TResult);
        }

        private static TResult ConversionBase<TArgument, TResult>(TArgument value, IFormatProvider formatProvider, Func<TArgument, IFormatProvider, TResult> converter)
        {
            return Convertible(value) ? converter(value, formatProvider) : default(TResult);
        }

        private static TResult? NullableConversionBase<TResult, TArgument>(TArgument value, Func<TArgument, TResult> converter) where TResult : struct
        {
            return (value != null) ? new TResult?(converter(value)) : null;
        }

        private static TResult? NullableConversionBase<TResult, TArgument>(TArgument value, int fromToBase, Func<TArgument, int, TResult> converter) where TResult : struct
        {
            return Convertible(value) ? new TResult?(converter(value, fromToBase)) : null;
        }

        private static TResult? NullableConversionBase<TResult, TArgument>(TArgument value, IFormatProvider formatProvider, Func<TArgument, IFormatProvider, TResult> converter) where TResult : struct
        {
            return Convertible(value) ? new TResult?(converter(value, formatProvider)) : null;
        }
    }
}
