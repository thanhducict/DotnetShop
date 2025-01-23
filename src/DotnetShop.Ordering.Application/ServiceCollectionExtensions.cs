using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetShop.Ordering.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOrderingApplication(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
