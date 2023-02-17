using CustomersStorage.CrossCutting.Exceptions;
using CustomersStorage.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CustomersStorage.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                await _next(context);
            }
            catch (ApplicationWarningException exception)
            {
                await HandleDefaultException(context, HttpStatusCode.BadRequest, exception, true);
            }
            catch (ApplicationException exception)
            {
                await HandleDefaultException(context, HttpStatusCode.BadRequest, exception);
            }
            catch (ValidationException exception)
            {
                await HandleDefaultException(context, HttpStatusCode.BadRequest, exception);
            }
            catch (UnauthorizedAccessException exception)
            {
                await HandleDefaultException(context, HttpStatusCode.Unauthorized, exception);
            }
            catch (Exception)
            {
                await HandleDefaultException(context, HttpStatusCode.InternalServerError);
            }

        }
        public async Task HandleDefaultException(HttpContext context, HttpStatusCode httpStatusCode, Exception exception = null, bool isWarning = false)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = @"application/json";
            if (isWarning)
            {
                context.Response.Headers.Add("Access-Control-Expose-Headers", "app-notification-type");
                context.Response.Headers.Add("app-notification-type", "warning");
            }
            var isCustomException = exception != null ? exception.GetType().IsSubclassOf(typeof(Exception)) : false;
            string responseString;

            if (isCustomException)
            {
                responseString = new Exception(exception?.Message).ToResponseMessage();
                await context.Response.WriteAsync(responseString);
                return;
            }

            responseString = new Exception("Server is not responding. Try later").ToResponseMessage();
            await context.Response.WriteAsync(responseString);
        }

    }
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
