using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class EmployeeTypeToBooleanConverter : IValueConverter
    {
        static EmployeeTypeToBooleanConverter()
        {
            Instance = new EmployeeTypeToBooleanConverter();
        }

        public static EmployeeTypeToBooleanConverter Instance { get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (short)value == System.Convert.ToInt16(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
