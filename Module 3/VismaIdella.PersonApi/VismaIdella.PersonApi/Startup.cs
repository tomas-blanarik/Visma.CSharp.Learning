using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VismaIdella.PersonApi.Application.Extensions;
using VismaIdella.PersonApi.Application.Infrastructure.Middlewares;

namespace VismaIdella.PersonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "VismaIdella.PersonApi", Version = "v1" }));
            services.AddApplicationLayer(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VismaIdella.PersonApi v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            // exception handling
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
