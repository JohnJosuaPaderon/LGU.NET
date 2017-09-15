using LGU.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class DialogModeEditToVisibilityConverter : IValueConverter
    {
        public static DialogModeEditToVisibilityConverter Instance { get; } = new DialogModeEditToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (DialogMode)value == DialogMode.Edit ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
