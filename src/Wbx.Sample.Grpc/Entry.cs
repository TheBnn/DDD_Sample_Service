using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Wbx.Sample.Grpc.Service;

using AutoMapper;
using MediatR;
using Services;
using Wbx.Sample.Grpc.Service.Mapping;

public static class Entry
{
    public static void AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpc();
        services.AddMediatR(typeof(Entry));

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ResponseMap());
            mc.AddProfile(new SampleMap());

        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        // services.AddGrpcHttpApi();
        // services.AddGrpcSwagger();
    }

    public static void UseGrpcServices(this WebApplication app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<SampleService>();
        });
    }
}
