using Core.ServicesConfiguration;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using QueueConsumer.Consumers;

namespace QueueConsumer.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InitWorker(this IServiceCollection services)
        {
            services.AddMessaging();
            services.StartBus();

            return services;
        }
        
        private static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<MessageConsumer>();
                cfg.AddConfiguredBus();
            });

            return services;
        }
    }
}
