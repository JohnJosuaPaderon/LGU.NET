using System;

namespace LGU.Utilities
{
    public static class DateTimeUtilities
    {
        public static double GetTotalDayMinuteDiff(DateTime left, DateTime right)
        {
			return (left.TimeOfDay - right.TimeOfDay).TotalMinutes;
        }
    }
}
