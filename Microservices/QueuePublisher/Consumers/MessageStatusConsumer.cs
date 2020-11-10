using Core.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace QueuePublisher.Consumers
{
    public class MessageStatusConsumer : IConsumer<IMessageStatus>
    {
        private ILogger<MessageStatusConsumer> logger;

        public MessageStatusConsumer(ILogger<MessageStatusConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<IMessageStatus> context)
        {
            var messageStatus = context.Message;
            logger.LogInformation("Sender: {0}, Status: {1}", messageStatus.Sender, messageStatus.Status);
        }
    }
}
