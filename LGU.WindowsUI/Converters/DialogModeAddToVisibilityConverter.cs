using LGU.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class DialogModeAddToVisibilityConverter : IValueConverter
    {
        public static DialogModeAddToVisibilityConverter Instance { get; } = new DialogModeAddToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (DialogMode)value == DialogMode.Add ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
