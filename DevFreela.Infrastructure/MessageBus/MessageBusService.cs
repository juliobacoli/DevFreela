using DevFreela.Core.Services;

namespace DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        public MessageBusService()
        {

        }

        public void Publish(string queue, byte[] message)
        {
            throw new System.NotImplementedException();
        }
    }
}
