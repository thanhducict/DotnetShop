using DotnetShop.Common.Messaging.MessageBroker;
using RabbitMQ.Client;

namespace DotnetShop.ShoppingCart.API.Producers
{
    public class CartCheckoutProducer(IConnection connection) : MessageProducer(connection)
    {
    }
}
