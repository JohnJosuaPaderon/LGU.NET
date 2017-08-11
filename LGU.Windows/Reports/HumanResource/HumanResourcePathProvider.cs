using LGU.Extensions;
using System.Configuration;

namespace LGU.Reports.HumanResource
{
    public sealed class HumanResourcePathProvider : IHumanResourcePathProvider
    {
        public HumanResourcePathProvider()
        {
            LocatorTemplate = SystemRuntime.ResolveReportTemplatePath(ConfigurationManager.AppSettings.GetString(AppendKey(nameof(LocatorTemplate))));
            LocatorSaveDirectory = SystemRuntime.ResolveReportPath(ConfigurationManager.AppSettings.GetString(AppendKey(nameof(LocatorSaveDirectory))));
        }

        private string AppendKey(string key)
        {
            return $"HumanResource.{key}";
        }

        public string LocatorTemplate { get; }
        public string LocatorSaveDirectory { get; }
    }
}
