using LGU.Models.HumanResource;
using MaterialDesignThemes.Wpf;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class FingerPrintToPackIconStateConverter : IValueConverter
    {
        public static FingerPrintToPackIconStateConverter Instance { get; } = new FingerPrintToPackIconStateConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((FingerPrintModel)value)?.Data != null ? PackIconKind.CheckCircle : PackIconKind.CloseCircle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
