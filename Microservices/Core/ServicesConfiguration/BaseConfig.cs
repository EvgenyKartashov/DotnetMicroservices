using Core.Services;
using MassTransit;
using MassTransit.ActiveMqTransport;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.ServicesConfiguration
{
    public static class BaseConfig
    {
        public static void AddConfiguredBus(this IServiceCollectionBusConfigurator busConfigurator)
        {
            ////RabbitMQ
            //busConfigurator.UsingRabbitMq((ctx, cfg) =>
            //{
            //    cfg.Host("rabbit", "/", configure =>
            //        {
            //            configure.Username("rabbitmq");
            //            configure.Password("rabbitmq");
            //        });
            //    cfg.ConfigureEndpoints(ctx);
            //});

            //ActiveMQ
            busConfigurator.UsingActiveMq((ctx, cfg) =>
            {
                cfg.Host("active", 61616, configure =>
                {
                    configure.Username("admin");
                    configure.Password("admin");
                });
                cfg.ConfigureEndpoints(ctx);
            });
        }

        public static IServiceCollection StartBus(this IServiceCollection services)
        {
            services.AddHostedService<BusService>();

            return services;
        }
    }
}
