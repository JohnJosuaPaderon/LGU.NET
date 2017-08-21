using LGU.Extensions;
using System;
using System.Configuration;

namespace LGU.Reports
{
    public abstract class ReportInfoProviderBase
    {
        public ReportInfoProviderBase(string appSettingOwner)
        {
            if (string.IsNullOrWhiteSpace(appSettingOwner))
            {
                throw new ArgumentException("Application settings owner is invalid.", nameof(appSettingOwner));
            }

            AppSettingOwner = appSettingOwner;
        }

        private string AppSettingOwner { get; }

        protected string GetReportTemplatePath(string key)
        {
            return SystemRuntime.ResolveReportTemplatePath(ConfigurationManager.AppSettings.GetString(AppendAppSettingOwner(key)));
        }

        protected string GetReportDirectory(string key)
        {
            return SystemRuntime.ResolveReportPath(ConfigurationManager.AppSettings.GetString(AppendAppSettingOwner(key)));
        }

        protected string AppendAppSettingOwner(string key)
        {
            return $"{AppSettingOwner}.{key}";
        }
    }
}
