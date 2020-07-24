using CrossCuttingIoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApi.Extensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjector.RegisterServices(services);
        }
    }
}
