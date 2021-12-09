using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using System;
using System.Reflection;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Database;
using VismaIdella.PersonApi.Application.Extensions;

namespace VismaIdella.PersonApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                LoggerConfiguration config = new LoggerConfiguration()
                    .WriteTo.Console()
                    .Enrich.WithExceptionDetails()
                    .Enrich.FromLogContext();

                if (environment == Environments.Development)
                {
                    config.MinimumLevel.Debug();
                }
                else
                {
                    config.MinimumLevel.Warning();
                }

                Log.Logger = config.CreateLogger();
                Log.Logger.Information(
                    "Application {app} is starting",
                    Assembly.GetExecutingAssembly().GetName().Name);

                var host = CreateHostBuilder(args).Build();

                // migrate the database
                host.MigrateDbContext<ApplicationContext>();

                await host.RunAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(
                    e,
                    "{err} occurred while executing application: {msg}",
                    e.GetType().Name,
                    e.Message);
            }
            finally
            {
                Log.Logger.Information(
                    "Application {app} is shutting down",
                    Assembly.GetExecutingAssembly().GetName().Name);
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    webBuilder.UseSerilog();
                });
    }
}
