using LGU.Reports.HumanResource;
using System;
using System.Globalization;
using System.Windows.Data;

namespace LGU.Converters
{
    public sealed class TimeLogExportOptionToDisplayConverter : IValueConverter
    {
        public static TimeLogExportOptionToDisplayConverter Instance { get; } = new TimeLogExportOptionToDisplayConverter();

        private const string ALL = "All";
        private const string SELECTED_DEPARTMENT = "Selected Department";
        private const string SELECTED_EMPLOYEE = "Selected Employee";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var exportOption = (TimeLogExportOption)value;

            switch (exportOption)
            {
                case TimeLogExportOption.All: return ALL;
                case TimeLogExportOption.SelectedDepartment: return SELECTED_DEPARTMENT;
                case TimeLogExportOption.SelectedEmployee: return SELECTED_EMPLOYEE;
                default: return ALL;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var exportOption = (string)value;

            switch (exportOption)
            {
                case ALL: return TimeLogExportOption.All;
                case SELECTED_DEPARTMENT: return TimeLogExportOption.SelectedDepartment;
                case SELECTED_EMPLOYEE: return TimeLogExportOption.SelectedEmployee;
                default: return TimeLogExportOption.All;
            }
        }
    }
}
