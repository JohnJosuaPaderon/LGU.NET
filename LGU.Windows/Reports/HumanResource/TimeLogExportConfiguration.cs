using LGU.Extensions;
using Newtonsoft.Json.Linq;
using System;

namespace LGU.Reports.HumanResource
{
    public class TimeLogExportConfiguration
    {
        public int LoginAmColumnIndex { get; set; }
        public int LogoutAmColumnIndex { get; set; }
        public int LoginPmColumnIndex { get; set; }
        public int LogoutPmColumnIndex { get; set; }
        public int LogRowIndexStart { get; set; }
        public int LogRowIndexEnd { get; set; }
        public ExcelCell FullNameCell { get; set; }

        public static explicit operator TimeLogExportConfiguration(JObject arg)
        {
            return arg != null ? FromJson(arg) : null;
        }

        public static TimeLogExportConfiguration FromJson(JObject jSource)
        {
            if (jSource == null)
            {
                throw new ArgumentNullException(nameof(jSource));
            }
            else
            {
                return new TimeLogExportConfiguration()
                {
                    FullNameCell = (ExcelCell)jSource["FullNameCell"],
                    LoginAmColumnIndex = jSource.GetInt32("LoginAmColumnIndex"),
                    LoginPmColumnIndex = jSource.GetInt32("LoginPmColumnIndex"),
                    LogoutAmColumnIndex = jSource.GetInt32("LogoutAmColumnIndex"),
                    LogoutPmColumnIndex = jSource.GetInt32("LogoutPmColumnIndex"),
                    LogRowIndexEnd = jSource.GetInt32("LogRowIndexEnd"),
                    LogRowIndexStart = jSource.GetInt32("LogRowIndexStart")
                };
            }
        }
    }
}
