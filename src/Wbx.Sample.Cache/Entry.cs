using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Wbx.Sample.Cache;

public static class Entry
{
    public static void AddCacheServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedRedisCache(options =>
        {
            options.InstanceName = "Sample";
            options.Configuration = "localhost";
        });
    }
}
