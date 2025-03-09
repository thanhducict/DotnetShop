using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DotnetShop.Common.Messaging.MessageBroker
{
    public class MessageConsumer : MessageBrokerBase
    {
        readonly AsyncEventingBasicConsumer _consumer;

        public MessageConsumer(IConnection connection) : base(connection)
        {
            _consumer = new AsyncEventingBasicConsumer(channel);
        }

        public async void AddListener(string exchangeName, string queueName, AsyncEventHandler<BasicDeliverEventArgs> handler)
        {
            _consumer.ReceivedAsync += handler;
            await channel.ExchangeDeclareAsync(exchangeName, type: ExchangeType.Fanout);
            await channel.QueueDeclareAsync(queueName, false, false, false, null);
            await channel.QueueBindAsync(queueName, exchangeName, string.Empty);
            await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: _consumer);
        }

        public void RemoveListener(AsyncEventHandler<BasicDeliverEventArgs> handler)
        {
            _consumer.ReceivedAsync -= handler;
        }

    }
}
