using Microsoft.Extensions.DependencyInjection;
using System;

namespace LGU
{
    public static class ServiceProvider
    {
        public static void Instantiate(IServiceCollection serviceCollection)
        {
            Current = serviceCollection.BuildServiceProvider();
        }

        public static IServiceProvider Current { get; private set; }
    }
}
