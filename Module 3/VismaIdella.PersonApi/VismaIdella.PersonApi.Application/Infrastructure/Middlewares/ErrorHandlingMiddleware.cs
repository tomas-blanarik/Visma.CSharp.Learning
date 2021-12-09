using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VismaIdella.PersonApi.Application.Exceptions;

namespace VismaIdella.PersonApi.Application.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityConflictException conflict)
            {
                _logger.LogError(
                    conflict,
                    "Error occurred while processing your request: {msg}",
                    conflict.Message);

                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(conflict.Message);
            }
            catch (EntityNotFoundException notFound)
            {
                _logger.LogError(
                    notFound,
                    "Error occurred while processing your request: {msg}",
                    notFound.Message);

                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(notFound.Message);
            }
        }
    }
}
