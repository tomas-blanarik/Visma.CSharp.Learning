using CSharpLearning.WebAPI.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CSharpLearning.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
            return app;
        }
    }
}
