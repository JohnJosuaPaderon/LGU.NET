using LGU.Entities.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.IO;

namespace LGU
{
    public static class ApplicationDomain
    {
        public static void Instantiate(IServiceCollection serviceCollection)
        {
            Services = serviceCollection.BuildServiceProvider();
        }

        public static IServiceProvider Services { get; private set; }
        public static string SystemDirectory { get; set; }
        public static string ReportDirectory { get; set; }
        public static string ReportTemplateDirectory { get; set; }
        public static User CurrentUser { get; set; }
        public static bool DebugMode { get; set; }

        public static string ResolveSystemPath(string path)
        {
            return ResolvePath(SystemDirectory, path);
        }

        public static string ResolveReportPath(string path)
        {
            return ResolvePath(ReportDirectory, path);
        }

        public static string ResolveReportTemplatePath(string path)
        {
            return ResolvePath(ReportTemplateDirectory, path);
        }

        private static string ResolvePath(string baseDirectory, string path)
        {
            if (path.StartsWith("~"))
            {
                path = path.Substring(2, path.Length - 2);
                return Path.Combine(baseDirectory, path);
            }
            else
            {
                return path;
            }
        }

        public static string LogByInfo
        {
            get
            {
                return CurrentUser?.DisplayName ?? "UNDEFINED";
            }
        }

        public static T GetService<T>()
        {
            return Services.GetService<T>();
        }
    }
}
