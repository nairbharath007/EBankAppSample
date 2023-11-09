
using EBankAppSample.Models;
using EBankAppSample.Exceptions;
using System.Text.Json;

namespace EBankAppSample.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomerNotFoundException ce)
            {
                await HandleException(context, ce);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }

        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            /*var errorResponse = new ErrorResponse(ex.Message);
            var result = JsonSerializer.Serialize(errorResponse);*/ //convert error objrct to json object

            var error = new ErrorResponse(ex.Message);
            if (ex is CustomerNotFoundException)
                error = new ErrorResponse(ex.Message)
                {
                    Message = ex.Message,
                    StatusCode = ((CustomerNotFoundException)ex).StatusCode
                };

            var result = JsonSerializer.Serialize(error);
            //configure my response
            context.Response.StatusCode=error.StatusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
