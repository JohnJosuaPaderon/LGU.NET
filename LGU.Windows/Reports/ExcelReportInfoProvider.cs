using LGU.Extensions;
using System.Configuration;

namespace LGU.Reports
{
    public abstract class ExcelReportInfoProvider : ReportInfoProvider
    {
        public ExcelReportInfoProvider(string appSettingOwner) : base(appSettingOwner)
        {
        }

        public ExcelCell GetCell(string key)
        {
            return (ExcelCell)ConfigurationManager.AppSettings.GetString(AppendAppSettingOwner(key));
        }
    }
}
