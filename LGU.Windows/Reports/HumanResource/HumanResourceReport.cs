using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class HumanResourceReport : IHumanResourceReport
    {
        public void ExportLocator(Locator locator, IExportEventHandler eventHandler)
        {
            using (var export = SystemRuntime.GetService<IExportLocator>())
            {
                export.EventHandler = eventHandler;
                export.Locator = locator;
                export.PrintAfterSave = true;
                export.Export();
            }
        }

        public async Task ExportLocatorAsync(Locator locator, IExportEventHandler eventHandler)
        {
            using (var export = SystemRuntime.GetService<IExportLocator>())
            {
                export.EventHandler = eventHandler;
                export.Locator = locator;
                export.PrintAfterSave = true;
                await export.ExportAsync();
            }
        }

        public void ExportTimeLog(IEnumerable<TimeLog> timeLogs, IExportEventHandler eventHandler)
        {
            throw new NotImplementedException();
        }

        public Task ExportTimeLogAsync(IEnumerable<TimeLog> timeLogs, IExportEventHandler eventHandler)
        {
            throw new NotImplementedException();
        }
    }
}
