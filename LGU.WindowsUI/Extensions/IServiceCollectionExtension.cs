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
    }
}
