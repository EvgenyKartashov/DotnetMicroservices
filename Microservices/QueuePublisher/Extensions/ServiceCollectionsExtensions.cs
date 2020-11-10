using Core.ServicesConfiguration;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using QueuePublisher.Consumers;

namespace QueuePublisher.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection InitWorker(this IServiceCollection services)
        {
            services.AddMessaging();
            services.StartBus();

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            return services;
        }

        private static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConfiguredBus();
                cfg.AddConsumer<MessageStatusConsumer>();
            });

            return services;
        }
    }
}
