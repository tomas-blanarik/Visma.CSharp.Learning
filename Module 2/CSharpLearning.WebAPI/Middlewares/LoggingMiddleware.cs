using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CSharpLearning.WebAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Authorization: Bearer <token>
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = context.Request.Headers["Authorization"];

                // do some validations
            }
            else
            {
                // validations
                context.Response.StatusCode = 401;
                return;
            }

            await _next(context);
        }
    }
}
