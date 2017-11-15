using LGU.Reports.HumanResource;
using LGU.Spreadsheet;
using Microsoft.Extensions.DependencyInjection;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection SetConnectionStringSource(this IServiceCollection instance)
        {
            instance.AddSingleton<IConnectionStringSource, ConnectionStringSource>();
            return instance;
        }

        public static IServiceCollection SetSystemAdministratorManager(this IServiceCollection instance)
        {
            instance.AddSingleton<ISystemAdministratorManager, SystemAdministratorManager>();
            return instance;
        }

        public static IServiceCollection EnableReporting(this IServiceCollection instance)
        {
            instance.AddSingleton<IExcelCharactersDecorator, ExcelCharactersDecorator>();

            instance.AddTransient<IExportLocator, ExportLocator>();
            instance.AddTransient<IExportTimeLog, ExportTimeLog>();
            instance.AddTransient<IExportActualTimeLog, ExportActualTimeLog>();
            instance.AddSingleton<ILocatorReportInfoProvider, LocatorReportInfoProvider>();
            instance.AddSingleton<ITimeLogReportInfoProvider, TimeLogReportInfoProvider>();
            instance.AddSingleton<IActualTimeLogReportInfoProvider, ActualTimeLogReportInfoProvider>();
            instance.AddSingleton<IHumanResourceReport, HumanResourceReport>();
            instance.AddSingleton<IExportPayrollContractual, ExportPayrollContractual>();
            instance.AddSingleton<IPayrollContractualHeaderWriter, PayrollContractualHeaderWriter>();
            instance.AddSingleton<IPayrollContractualReportInfoProvider, PayrollContractualReportInfoProvider>();

            return instance;
        }
    }
}
