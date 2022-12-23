using CsvParser.Core.Interfaces;
using CsvParser.Core.Models;
using CsvParser.Persistence.Data;
using CsvParser.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CsvParser.Persistence.Configuration;

public static class PersistenceConfiguration
{
    public static void AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IRepository<Value>, Repository<Value>>();
        services.AddScoped<IRepository<Result>, Repository<Result>>();
    }
}
