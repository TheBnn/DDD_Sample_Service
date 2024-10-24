using Microsoft.Extensions.DependencyInjection;
using Wbx.Simple.RabbitMq.Producer;

namespace Wbx.Simple.RabbitMq.Producer;

public static class Entry
{
    public static void AddRabbitMQProducesServices(this IServiceCollection services)
    {
        services.AddScoped<IRabbitMqService, RabbitMqService>();
    }
}
