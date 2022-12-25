using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Persistence.Data;
using CsvParser.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CsvParser.Persistence.Configuration;

public static class PersistenceConfiguration
{
    public static void AddPersistence(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<DataContext>(options =>
        {
            if(connectionString == null)
                options.UseInMemoryDatabase(nameof(DataContext));
            else
                options.UseSqlServer(connectionString);
        });

        services.AddScoped<IRepository<Value>, Repository<Value>>();
        services.AddScoped<IRepository<Result>, Repository<Result>>();
    }

    public static void UseCleanDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var scopedProvider = scope.ServiceProvider;
            var dbContext = scopedProvider.GetRequiredService<DataContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
