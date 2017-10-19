using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class EmployeeTypeToVisibilityConverter : IValueConverter
    {
        static EmployeeTypeToVisibilityConverter()
        {
            Instance = new EmployeeTypeToVisibilityConverter();
        }

        public static EmployeeTypeToVisibilityConverter Instance { get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (short)value == System.Convert.ToInt16(parameter) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
