using MaterialDesignThemes.Wpf;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class NullableToPackIconStateConverter : IValueConverter
    {
        public static NullableToPackIconStateConverter Instance { get; } = new NullableToPackIconStateConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? PackIconKind.CheckCircle : PackIconKind.CloseCircle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
