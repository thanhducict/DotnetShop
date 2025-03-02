using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace DotnetShop.Common.Messaging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageBrooker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnection>(sp =>
            {
                var connectionFactory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };

                return connectionFactory.CreateConnectionAsync().Result;
            });


            return services;
        }
    }
}
