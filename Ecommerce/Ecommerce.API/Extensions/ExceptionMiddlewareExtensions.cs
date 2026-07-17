using Ecommerce.API.Responses;
using Ecommerce.Domain.Validation;
using Microsoft.AspNetCore.Diagnostics;

namespace Ecommerce.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature == null)
                        return;

                    var exception = contextFeature.Error;

                    var errorDetails = exception switch
                    {
                        DomainExceptionValidation => new ErrorDetails
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = exception.Message
                        },

                        ArgumentException => new ErrorDetails
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = exception.Message
                        },

                        InvalidOperationException => new ErrorDetails
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            Message = exception.Message
                        },

                        _ => new ErrorDetails
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Ocorreu um erro interno."
                        }
                    };

                    if (env.IsDevelopment())
                    {
                        errorDetails.Trace = exception.StackTrace;
                    }

                    context.Response.StatusCode = errorDetails.StatusCode;

                    await context.Response.WriteAsJsonAsync(errorDetails);
                });
            });
        }
    }
}
