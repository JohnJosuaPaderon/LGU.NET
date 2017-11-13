namespace LGU.Reports.HumanResource
{
    public interface IActualTimeLogReportInfoProvider
    {
        string Template { get; }
        string SaveDirectory { get; }
        bool PrintAfterSave { get; }
        int LogRowStart { get; }
        ExcelCell EmployeeCell { get; }
        ExcelCell DepartmentCell { get; }
        ExcelCell CutOffCell { get; }
        int LoginColumn { get; }
        int LogoutColumn { get; }
    }
}
