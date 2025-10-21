using CrudJWT.Errors;
using System.Text.Json;

namespace CrudJWT.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";

                switch (ex)
                {
                    case ArgumentNullException:
                    case ArgumentException:
                    case InvalidDataException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case UnauthorizedAccessException:
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        break;

                    case InvalidOperationException:
                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                        break;

                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                var response = _environment.IsDevelopment() ?
                    new ApiException(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) :
                    new ApiException(context.Response.StatusCode.ToString(), ex.Message, "Internal server error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
