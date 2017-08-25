using System;

namespace LGU.Extensions
{
    public static class ValueRangeExtension
    {
        public static string ToFormattedString(this ValueRange<DateTime> instance)
        {
            if (instance.Begin.Date == instance.End.Date)
            {
                return string.Format("{0:MMMM d, yyyy}", instance.Begin);
            }
            else if (instance.Begin.Month == instance.End.Month && instance.Begin.Year == instance.End.Year)
            {
                return string.Format("{0:MMMM} {0:dd} - {1:dd} {1:yyyy}", instance.Begin, instance.End);
            }
            else if (instance.Begin.Year == instance.End.Year)
            {
                return string.Format("{0:MMMM d} - {1:MMMM d} {0:yyyy}", instance.Begin, instance.End);
            }
            else
            {
                return string.Format("{0:MMMM d, yyyy} - {1:MMMM d, yyyy}", instance.Begin, instance.End);
            }
        }
    }
}
