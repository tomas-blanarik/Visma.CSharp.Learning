using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.SqlClient;

namespace VismaIdella.PersonApi.Application.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDbContext<TContext>(this IHost host) where TContext : DbContext
        {
            using IServiceScope scope = host.Services.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;
            ILogger<TContext> logger = provider.GetRequiredService<ILogger<TContext>>();
            TContext context = provider.GetRequiredService<TContext>();

            try
            {
                logger.LogDebug("Migrating database associated with context {context}", typeof(TContext).Name);

                Policy.Handle<SqlException>()
                    .WaitAndRetry(new[] { TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(7) })
                    .Execute(() => context.Database.Migrate());

                logger.LogDebug("Successfully migrated database associated with context {context}", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "An error occurred while migrating database associated with context {context}: {err}",
                    typeof(TContext).Name, ex.Message);
            }

            return host;
        }
    }
}
