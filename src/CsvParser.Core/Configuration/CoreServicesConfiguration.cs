using CsvParser.Core.Interfaces;
using CsvParser.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CsvParser.Core.Configuration
{
    public static class CoreServicesConfiguration
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ICsvService, CsvService>();
            services.AddScoped<IValuesParser, ValuesParser>();
            services.AddScoped<IResultCalculator, ResultCalculator>();
        }
    }
}
