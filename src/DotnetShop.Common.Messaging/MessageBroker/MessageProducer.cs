using RabbitMQ.Client;
using System.Text;

namespace DotnetShop.Common.Messaging.MessageBroker
{
    public class MessageProducer(IConnection connection) : MessageBrokerBase(connection)
    {
        public async Task SendMessage(string exchangeName, string message)
        {
            await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout);

            var body = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchange: exchangeName, routingKey: string.Empty, body: body);
        }
    }
}
