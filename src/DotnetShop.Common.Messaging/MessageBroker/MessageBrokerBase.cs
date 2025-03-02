using RabbitMQ.Client;
using System.Text;

namespace DotnetShop.Common.Messaging.MessageBroker
{
    public abstract class MessageBrokerBase
    {
        private readonly IConnection _connection;
        protected readonly IChannel channel;

        public MessageBrokerBase(IConnection connection)
        {
            _connection = connection;
            channel = _connection.CreateChannelAsync().Result;
        }
    }
}
