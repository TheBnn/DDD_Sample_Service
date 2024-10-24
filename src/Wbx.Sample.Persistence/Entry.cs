using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Wbx.Sample.Persistence;

using Repository;
using Domain.Repository;
using Persistence.DatabaseContext;
using Wbx.Sample.Domain.Models;

public static class Entry
{

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        var settings = configuration.GetSection("PM_DB").Get<DbSettings>();
        services.AddDbContextFactory<Context>(options =>
        {
            options.UseNpgsql(settings!.ConnectionString);
        });

        services.AddTransient<IRepository<Entities.Sample, GetSamplesParams>, SampleRepositoty>();
    }
}
