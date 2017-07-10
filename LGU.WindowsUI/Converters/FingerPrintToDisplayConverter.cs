using LGU.Entities.Core;
using LGU.Models.HumanResource;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class FingerPrintToDisplayConverter : IValueConverter
    {
        public static FingerPrintToDisplayConverter Instance { get; } = new FingerPrintToDisplayConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FingerPrint fingerPrint)
            {
                return $"{fingerPrint.HandType} {FingerTypeConverter.GetDisplay(fingerPrint.FingerType)}";
            }
            else if (value is FingerPrintModel fingerPrintModel)
            {
                return $"{fingerPrintModel.HandType} {FingerTypeConverter.GetDisplay(fingerPrintModel.FingerType)}";
            }
            else
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
