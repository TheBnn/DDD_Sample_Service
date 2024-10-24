using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Wbx.Sample.Application;
using Wbx.Sample.Grpc.Service;
//using Wbx.Sample.Grpc.Service;
using Wbx.Sample.Persistence;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

builder.Configuration.AddConfiguration(config);

builder.Services.AddGrpcServices();
builder.Services.AddApplicationServices();
builder.Services.AddRouting();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wbx.Sample.Service", Version = "v1" });
//}

//);

builder.Services.AddPersistenceServices(builder.Configuration);

//builder.Services.AddGrpcHost();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wbx.Sample.Service V1");
//}
//);
app.UseRouting();
app.UseGrpcServices();



app.Run();
