namespace LGU.Reports.HumanResource
{
    public sealed class LocatorReportInfoProvider : ReportInfoProvider, ILocatorReportInfoProvider
    {
        public LocatorReportInfoProvider() : base("HumanResource.Locator")
        {
            Template = GetReportTemplatePath(nameof(Template));
            SaveDirectory = GetReportDirectory(nameof(SaveDirectory));
            PrintAfterSave = GetBoolean(nameof(PrintAfterSave));
        }

        public string Template { get; }
        public string SaveDirectory { get; }
        public bool PrintAfterSave { get; }
    }
}
