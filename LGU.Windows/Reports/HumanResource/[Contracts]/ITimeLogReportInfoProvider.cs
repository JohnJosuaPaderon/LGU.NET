namespace LGU.Reports.HumanResource
{
    public interface ITimeLogReportInfoProvider
    {
        string Template { get; }
        string SaveDirectory { get; }
        bool PrintAfterSave { get; }
        int LogRowStart { get; }
        int AmLoginColumn { get; }
        int AmLogoutColumn { get; }
        int PmLoginColumn { get; }
        int PmLogoutColumn { get; }
        int OtLoginColumn { get; }
        int OtLogoutColumn { get; }
        ExcelCell CutOffCell { get; }
        ExcelCell EmployeeCell { get; }
        string TimeLogFormat { get; }
        string PathFormat { get; }
        bool IncludeFileMap { get; }
    }
}
