using Core.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace QueueConsumer.Consumers
{
    public class MessageConsumer : IConsumer<IMessage>
    {
        private readonly string name;
        private readonly ILogger<MessageConsumer> logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            name = typeof(MessageConsumer).Name;
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<IMessage> context)
        {
            try
            {
                logger.LogInformation("Message: {0}", context.Message.Data);

                await context.RespondAsync<IMessageStatus>(new
                {
                    Sender = name,
                    Status = "OK"
                });
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {0}", ex.Message);

                await context.RespondAsync<IMessageStatus>(new
                {
                    Sender = name,
                    Status = "Fail"
                });
            }
        }
    }
}
