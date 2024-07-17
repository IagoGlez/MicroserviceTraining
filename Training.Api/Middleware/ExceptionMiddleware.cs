using System.Net;
using System.Text.Json;

namespace Training.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ha ocurrido un error no contemplado.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                error = exception.Message
            };

            switch (exception)
            {
                case ArgumentException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    response = new { error = "Argumento inválido." };
                    break;
                case UnauthorizedAccessException _:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    response = new { error = "No dispone de acceso para este recurso" };
                    break;
                case TimeoutException _:
                    statusCode = (int)HttpStatusCode.RequestTimeout;
                    response = new { error = "Se ha superado el tiempo limite para tu petición." };
                    break;
                case ApplicationException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    response = new { error = "Ha ocurrido un error en la aplicación" };
                    break;
                case FormatException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    response = new { error = "Formato inválido" };
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    response = new { error = "Ha ocurrido un error no contemplado." };
                    break;
            }

            context.Response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    }
}
