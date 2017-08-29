﻿using LGU.Entities.HumanResource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LGU.Reports.HumanResource
{
    public sealed class HumanResourceReport : IHumanResourceReport
    {
        public void ExportLocator(ILocator locator, IExportEventHandler eventHandler)
        {
            using (var export = SystemRuntime.GetService<IExportLocator>())
            {
                export.EventHandler = eventHandler;
                export.Locator = locator;
                export.PrintAfterSave = true;
                export.Export();
            }
        }

        public async Task ExportLocatorAsync(ILocator locator, IExportEventHandler eventHandler)
        {
            using (var export = SystemRuntime.GetService<IExportLocator>())
            {
                export.EventHandler = eventHandler;
                export.Locator = locator;
                export.PrintAfterSave = true;
                await export.ExportAsync();
            }
        }

        public void ExportTimeLog(IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler)
        {
            using (var export = SystemRuntime.GetService<IExportTimeLog>())
            {
                export.EventHandler = eventHandler;
                export.TimeLogs = timeLogs;
                export.CutOff = cutOff;
                export.ExportOption = exportOption;
                export.FileSegregration = fileSegregation;
                export.Export();
            }
        }

        public async Task ExportTimeLogAsync(IEnumerable<ITimeLog> timeLogs, ValueRange<DateTime> cutOff, TimeLogExportOption exportOption, TimeLogFileSegregation fileSegregation, IExportEventHandler eventHandler)
        {
            using (var export = SystemRuntime.GetService<IExportTimeLog>())
            {
                export.EventHandler = eventHandler;
                export.TimeLogs = timeLogs;
                export.CutOff = cutOff;
                export.ExportOption = exportOption;
                export.FileSegregration = fileSegregation;
                await export.ExportAsync();
            }
        }
    }
}
