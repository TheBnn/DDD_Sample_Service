using Microsoft.Extensions.DependencyInjection;

namespace Wbx.Simple.RabbitMq.Consumer;

public static class Entry
{
    public static void AddRabbitMQConsumerServices(this IServiceCollection services)
    {
        services.AddHostedService<RabbitMqListener>();
    }
}
