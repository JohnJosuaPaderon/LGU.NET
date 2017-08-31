namespace LGU.Reports.HumanResource
{
    public sealed class TimeLogReportInfoProvider : ExcelReportInfoProvider, ITimeLogReportInfoProvider
    {
        public TimeLogReportInfoProvider() : base("HumanResource.TimeLog")
        {
            Template = GetReportTemplatePath(nameof(Template));
            SaveDirectory = GetReportDirectory(nameof(SaveDirectory));
            PrintAfterSave = GetBoolean(nameof(PrintAfterSave));
            LogRowStart = GetInt32(nameof(LogRowStart));
            AmLoginColumn = GetInt32(nameof(AmLoginColumn));
            AmLogoutColumn = GetInt32(nameof(AmLogoutColumn));
            PmLoginColumn = GetInt32(nameof(PmLoginColumn));
            PmLogoutColumn = GetInt32(nameof(PmLogoutColumn));
            CutOffCell = GetCell(nameof(CutOffCell));
            EmployeeCell = GetCell(nameof(EmployeeCell));
            OtLoginColumn = GetInt32(nameof(OtLoginColumn));
            OtLogoutColumn = GetInt32(nameof(OtLogoutColumn));
            TimeLogFormat = GetString(nameof(TimeLogFormat));
            PathFormat = GetString(nameof(PathFormat));
            IncludeFileMap = GetBoolean(nameof(IncludeFileMap));
        }

        public string Template { get; }
        public string SaveDirectory { get; }
        public bool PrintAfterSave { get; }
        public int LogRowStart { get; }
        public int AmLoginColumn { get; }
        public int AmLogoutColumn { get; }
        public int PmLoginColumn { get; }
        public int PmLogoutColumn { get; }
        public ExcelCell CutOffCell { get; }
        public ExcelCell EmployeeCell { get; }
        public int OtLoginColumn { get; }
        public int OtLogoutColumn { get; }
        public string TimeLogFormat { get; }
        public string PathFormat { get; }
        public bool IncludeFileMap { get; }
    }
}
