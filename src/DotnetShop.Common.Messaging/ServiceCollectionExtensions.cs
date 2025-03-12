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
                var connectionFactory = new ConnectionFactory();
                connectionFactory.Uri = new Uri(configuration["MessageBroker:Uri"]);
                connectionFactory.UserName = configuration["MessageBroker:UserName"];
                connectionFactory.Password = configuration["MessageBroker:Password"];

                return connectionFactory.CreateConnectionAsync().Result;
            });

            return services;
        }
    }
}
