using LGU.Extensions;
using System.Configuration;

namespace LGU.Reports.HumanResource
{
    public sealed class HumanResourceReportInfoProvider : ReportInfoProviderBase, IHumanResourceReportInfoProvider
    {
        public HumanResourceReportInfoProvider() : base("HumanResource")
        {
            LocatorTemplate = GetReportTemplatePath(nameof(LocatorTemplate));
            LocatorSaveDirectory = GetReportDirectory(nameof(LocatorSaveDirectory));
            PrintLocatorAfterSave = ConfigurationManager.AppSettings.GetBoolean(AppendAppSettingOwner(nameof(PrintLocatorAfterSave)));

            TimeLogTemplate = GetReportTemplatePath(nameof(TimeLogTemplate));
            TimeLogSaveDirectory = GetReportDirectory(nameof(TimeLogSaveDirectory));
            PrintTimeLogAfterSave = ConfigurationManager.AppSettings.GetBoolean(AppendAppSettingOwner(nameof(PrintTimeLogAfterSave)));
        }

        public string LocatorTemplate { get; }
        public string LocatorSaveDirectory { get; }
        public bool PrintLocatorAfterSave { get; }

        public string TimeLogTemplate { get; }
        public string TimeLogSaveDirectory { get; }
        public bool PrintTimeLogAfterSave { get; }
    }
}
