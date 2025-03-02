using DotnetShop.Common.Behaviors;
using DotnetShop.Common.Messaging;
using DotnetShop.Common.Messaging.MessageBroker;
using DotnetShop.Ordering.Application.Orders.EventHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DotnetShop.Ordering.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddMessageBrooker(configuration);
            services.AddSingleton<MessageConsumer>();
            services.AddHostedService<OrderCreatedEventHandler>();

            return services;
        }
    }
}
