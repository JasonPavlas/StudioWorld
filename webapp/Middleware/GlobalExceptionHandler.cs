using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace webapp.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger, 
            IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred");
            
            var problemDetails = new
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "An error occurred while processing your request.",
                Detail = _environment.IsDevelopment() 
                    ? exception.Message 
                    : "An internal server error has occurred.",
                TraceId = httpContext.TraceIdentifier
            };
            
            if (httpContext.Request.Headers.Accept.Contains("application/json"))
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.ContentType = "application/json";
                
                var json = JsonSerializer.Serialize(problemDetails);
                await httpContext.Response.WriteAsync(json, cancellationToken);
            }
            else
            {
                // For non-API requests, redirect to the error page
                httpContext.Response.Redirect("/Home/Error");
            }
            
            return true;
        }
    }
}
