using EasyCaching.Core.Configurations;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VismaIdella.PersonApi.Application.Database;
using VismaIdella.PersonApi.Application.Services;

namespace VismaIdella.PersonApi.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEFSecondLevelCache(options =>
            {
                options.UseEasyCachingCoreProvider("Redis")
                    .DisableLogging(false)
                    .SkipCachingResults(result => result.Value == null || (result.Value is EFTableRows rows && rows.RowsCount == 0));
            });

            services.AddEasyCaching(opts =>
            {
                opts.UseRedis(config =>
                {
                    config.EnableLogging = true;
                    config.DBConfig.AllowAdmin = true;
                    config.DBConfig.SyncTimeout = 10000;
                    config.DBConfig.AsyncTimeout = 10000;
                    config.DBConfig.Endpoints.Add(new ServerEndPoint(configuration.GetConnectionString("Redis"), 6379));
                    config.DBConfig.Database = 0;
                }, "Redis");
            });

            services.AddDbContext<ApplicationContext>((provider, options) =>
            {
                string connectionString = configuration.GetConnectionString("Default");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                options.AddInterceptors(provider.GetRequiredService<SecondLevelCacheInterceptor>());
            });

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ITodoListService, TodoListService>();

            return services;
        }
    }
}
