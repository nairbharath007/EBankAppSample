using System.Net;

namespace EBankAppSample.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public ErrorResponse(string message)
        {
            Message = message;
            StatusCode = (int) HttpStatusCode.InternalServerError;
        }
    }
}
