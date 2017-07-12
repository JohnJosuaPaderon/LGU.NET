using Microsoft.Extensions.DependencyInjection;

namespace LGU.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection SetConnectionStringSource(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConnectionStringSource, ConnectionStringSource>();
            return serviceCollection;
        }

        public static IServiceCollection SetSystemAdministratorManager(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISystemAdministratorManager, SystemAdministratorManager>();
            return serviceCollection;
        }
    }
}
