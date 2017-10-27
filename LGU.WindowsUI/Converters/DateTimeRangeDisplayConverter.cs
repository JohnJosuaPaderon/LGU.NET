using LGU.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class DateTimeRangeConverter : IValueConverter
    {
        public static DateTimeRangeConverter Instance { get; } = new DateTimeRangeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var range = (ValueRangeModel<DateTime>)value;

            if (range == null)
            {
                return Binding.DoNothing;
            }
            else if (range.Begin.Date == range.End.Date)
            {
                return string.Format("{0:MMMM dd, yyyy}", range.Begin);
            }
            else if (range.Begin.Month == range.End.Month && range.Begin.Year == range.End.Year)
            {
                return string.Format("{0:MMMM} {0:dd} - {1:dd}, {1:yyyy}", range.Begin, range.End);
            }
            else if (range.Begin.Year == range.End.Year)
            {
                return string.Format("{0:MMMM dd} - {1:MMMM dd}, {0:yyyy}", range.Begin, range.End);
            }
            else
            {
                return string.Format("{0:MMMM dd, yyyy} - {1:MMMM dd, yyyy}", range.Begin, range.End);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
