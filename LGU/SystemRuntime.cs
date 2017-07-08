using LGU.Entities.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LGU
{
    public static class SystemRuntime
    {
        public static void Instantiate(IServiceCollection serviceCollection)
        {
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        public static string SystemDirectory { get; set; }
        public static User CurrentUser { get; set; }

        public static string ResolveSystemPath(string path)
        {
            if (path.StartsWith("~"))
            {
                path = path.Substring(2, path.Length - 2);
                return Path.Combine(SystemDirectory, path);
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
    }
}
