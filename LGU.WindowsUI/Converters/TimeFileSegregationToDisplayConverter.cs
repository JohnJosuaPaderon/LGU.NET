using LGU.Reports.HumanResource;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class TimeFileSegregationToDisplayConverter : IValueConverter
    {
        public static TimeFileSegregationToDisplayConverter Instance { get; } = new TimeFileSegregationToDisplayConverter();

        private const string ONE_FILE = "One File";
        private const string PER_DEPARTMENT = "Per Department";
        private const string PER_EMPLOYEE = "Per Employee";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileSegregation = (TimeLogFileSegregation)value;

            switch (fileSegregation)
            {
                case TimeLogFileSegregation.OneFile: return ONE_FILE;
                case TimeLogFileSegregation.PerDepartment: return PER_DEPARTMENT;
                case TimeLogFileSegregation.PerEmployee: return PER_EMPLOYEE;
                default: return ONE_FILE;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileSegregation = (string)value;

            switch (fileSegregation)
            {
                case ONE_FILE: return TimeLogFileSegregation.OneFile;
                case PER_DEPARTMENT: return TimeLogFileSegregation.PerDepartment;
                case PER_EMPLOYEE: return TimeLogFileSegregation.PerEmployee;
                default: return TimeLogFileSegregation.OneFile;
            }
        }
    }
}
