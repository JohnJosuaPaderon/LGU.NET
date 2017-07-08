using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class NullableToBooleanConverter : IValueConverter
    {
        public static NullableToBooleanConverter Instance { get; } = new NullableToBooleanConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
