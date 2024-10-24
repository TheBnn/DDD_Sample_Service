using Microsoft.EntityFrameworkCore;

namespace Wbx.Sample.Persistence.DatabaseContext;

using Wbx.Sample.Persistence.Entities;
using Microsoft.Extensions.Configuration;
using Wbx.Sample.Persistence.DatabaseContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
      : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sample>();
    }


    /// <summary>
    /// Представляет таблицу пример.
    /// </summary>
    public virtual DbSet<Sample> Samples { get; set; }
}
