using DotnetShop.Common.Messaging.MessageBroker;
using Microsoft.Extensions.Hosting;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers
{
    public class OrderCreatedEventHandler(MessageConsumer messageConsumer) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            messageConsumer.AddListener("Checkout", "OrderCreated", (_, args) =>
            {
                return Task.CompletedTask;
            });

            return Task.CompletedTask;
        }
    }
}
