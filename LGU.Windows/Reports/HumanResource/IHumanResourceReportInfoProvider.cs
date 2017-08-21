namespace LGU.Reports.HumanResource
{
    public interface IHumanResourceReportInfoProvider
    {
        string LocatorTemplate { get; }
        string LocatorSaveDirectory { get; }
        bool PrintLocatorAfterSave { get; }

        string TimeLogTemplate { get; }
        string TimeLogSaveDirectory { get; }
        bool PrintTimeLogAfterSave { get; }
    }
}
