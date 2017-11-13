namespace LGU.Reports.HumanResource
{
    public sealed class ActualTimeLogReportInfoProvider : ExcelReportInfoProvider, IActualTimeLogReportInfoProvider
    {
        private const string APP_SETTING_OWNER = "HumanResource.ActualTimeLog";

        public ActualTimeLogReportInfoProvider() : base(APP_SETTING_OWNER)
        {
            Template = GetReportTemplatePath(nameof(Template));
            SaveDirectory = GetReportDirectory(nameof(SaveDirectory));
            PrintAfterSave = GetBoolean(nameof(PrintAfterSave));
            LogRowStart = GetInt32(nameof(LogRowStart));
            EmployeeCell = GetCell(nameof(EmployeeCell));
            DepartmentCell = GetCell(nameof(DepartmentCell));
            CutOffCell = GetCell(nameof(CutOffCell));
            LoginColumn = GetInt32(nameof(LoginColumn));
            LogoutColumn = GetInt32(nameof(LogoutColumn));
        }

        public string Template { get; }
        public string SaveDirectory { get; }
        public bool PrintAfterSave { get; }
        public int LogRowStart { get; }
        public ExcelCell EmployeeCell { get; }
        public ExcelCell DepartmentCell { get; }
        public ExcelCell CutOffCell { get; }
        public int LoginColumn { get; }
        public int LogoutColumn { get; }
    }
}
