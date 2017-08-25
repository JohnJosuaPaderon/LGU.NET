namespace LGU.Reports.HumanResource
{
    public interface ILocatorReportInfoProvider
    {
        string Template { get; }
        string SaveDirectory { get; }
        bool PrintAfterSave { get; }
    }
}
