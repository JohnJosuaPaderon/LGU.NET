using LGU.EntityManagers;
using LGU.EntityProcesses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace LGU.Extensions
{
    public static partial class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection instance)
        {
            Debug.WriteLine($"Integrating SQL Server : {DateTime.Now.ToString("HH:mm:ss")}");

            #region System
            instance.AddSingleton<IGetSystemDate, GetSystemDate>();
            instance.AddSingleton<ISystemManager, SystemManager>();
            #endregion

            instance.UseSqlServerForCore();
            instance.UseSqlServerForHumanResource();

            Debug.WriteLine($"SQL Server integrated successfully : {DateTime.Now.ToString("HH:mm:ss")}");

            return instance;
        }
    }
}
