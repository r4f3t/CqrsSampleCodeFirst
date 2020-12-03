
using CqrsSampleFirst.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsSampleFirst.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var CurrentDatabase = configuration.GetConnectionString("CurrentDatabase");

            var connectionString = configuration.GetConnectionString(CurrentDatabase);

            if (CurrentDatabase == "PostgreSQLDatabase")
            {
                services.AddDbContext<TestDbContext>(options =>

             options.UseNpgsql(connectionString,
                             x =>
                             {
                                 x.MigrationsHistoryTable("__MigrationsHistoryOfCore");
                             }));
                services.AddScoped<ITestDbContext>(provider => provider.GetService<TestDbContext>());

            }

            return services;
        }
    }
}
