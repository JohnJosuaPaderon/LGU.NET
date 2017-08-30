using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public static BooleanToVisibilityConverter Instance { get; } = new BooleanToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
