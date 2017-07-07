using LGU.EntityManagers;
using LGU.EntityProcesses;
using Microsoft.Extensions.DependencyInjection;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IGetSystemDate, GetSystemDate>();
            serviceCollection.AddTransient<ISystemManager, SystemManager>();
            return serviceCollection;
        }
    }
}
