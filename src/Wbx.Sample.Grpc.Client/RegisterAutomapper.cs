using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Wbx.Sample.Grpc.Client;

public static class RegisterAutomapper
{
    public static void RegisterMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
