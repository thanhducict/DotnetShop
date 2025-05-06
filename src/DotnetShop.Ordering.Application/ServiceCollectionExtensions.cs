using DotnetShop.Common;
using DotnetShop.Common.Messaging;
using DotnetShop.Common.Messaging.MessageBroker;
using DotnetShop.Ordering.Application.Orders.EventHandlers.Domain;
using DotnetShop.Ordering.Application.Orders.EventHandlers.Integration;
using DotnetShop.Ordering.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetShop.Ordering.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCommon();
            services.AddMessageBrooker(configuration);
            services.AddSingleton<MessageProducer>();
            services.AddSingleton<MessageConsumer>();
            services.AddHostedService<CartCheckoutEventHandler>();

            services.AddScoped<IPublisher<IDomainEvent>, OrderEventPublisher>();
            services.AddScoped<ISubscriber<OrderCreatedEvent>, OrderCreatedEventHandler>();
            services.AddScoped<ISubscriber<OrderUpdatedEvent>, OrderUpdatedEventHandler>();

            return services;
        }
    }
}
