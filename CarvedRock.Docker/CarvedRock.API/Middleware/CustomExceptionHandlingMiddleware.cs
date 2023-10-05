using Microsoft.AspNetCore.Http;
using System.Net;

namespace CarvedRock.API.Middleware
{
    public class CustomExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionHandlingMiddleware> logger;

        public CustomExceptionHandlingMiddleware(RequestDelegate next,ILogger<CustomExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleGlobalExceptions(httpContext, ex);
            }
        }

        private Task HandleGlobalExceptions(HttpContext httpContext,Exception exception)
        {
            if(exception is ApplicationException)
            {
                this.logger.LogWarning($"Validation error occured in api. error message:{exception.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return httpContext.Response.WriteAsJsonAsync(new { exception.Message });
            }
            else
            {
                var errorID = Guid.NewGuid().ToString();
                this.logger.LogError(exception, $"Error occured in api: {errorID}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return httpContext.Response.WriteAsJsonAsync(new
                {
                    ErrorID = errorID,
                    Message = exception.Message
                });
            }
        }
    }
}
