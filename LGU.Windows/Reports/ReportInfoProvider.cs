using LGU.Extensions;
using System;
using System.Configuration;

namespace LGU.Reports
{
    public abstract class ReportInfoProvider
    {
        public ReportInfoProvider(string appSettingOwner)
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
            return SystemRuntime.ResolveReportTemplatePath(GetString(key));
        }

        protected string GetReportDirectory(string key)
        {
            return SystemRuntime.ResolveReportPath(GetString(key));
        }

        protected string AppendAppSettingOwner(string key)
        {
            return $"{AppSettingOwner}.{key}";
        }

        protected bool GetBoolean(string key)
        {
            return ConfigurationManager.AppSettings.GetBoolean(AppendAppSettingOwner(key));
        }

        protected int GetInt32(string key)
        {
            return ConfigurationManager.AppSettings.GetInt32(AppendAppSettingOwner(key));
        }

        protected decimal GetDecimal(string key)
        {
            return ConfigurationManager.AppSettings.GetDecimal(AppendAppSettingOwner(key));
        }

        protected string GetString(string key)
        {
            return ConfigurationManager.AppSettings.GetString(AppendAppSettingOwner(key));
        }
    }
}
