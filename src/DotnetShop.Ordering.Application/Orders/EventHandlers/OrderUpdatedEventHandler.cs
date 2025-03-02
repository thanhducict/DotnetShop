using DotnetShop.Common.Messaging.MessageBroker;
using Microsoft.Extensions.Hosting;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers
{
    public class OrderUpdatedEventHandler(MessageConsumer messageConsumer) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            messageConsumer.AddListener("UpdateOrder", "OrderUpdated", (_, args) =>
            {
                return Task.CompletedTask;
            });

            return Task.CompletedTask;
        }
    }
}
