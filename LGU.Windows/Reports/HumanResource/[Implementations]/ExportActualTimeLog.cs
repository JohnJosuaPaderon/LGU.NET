using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class ExportActualTimeLog : ExcelExportBase, IExportActualTimeLog
    {
        public bool PrintAfterSave { get; set; }
        public IEnumerable<TimeLog> TimeLogs { get; set; }
        private string Template { get; }
        private string SaveDirectory { get; }

        public void Export()
        {
            OpenTemplate(Template);
        }

        public Task ExportAsync()
        {
            throw new NotImplementedException();
        }
    }
}
