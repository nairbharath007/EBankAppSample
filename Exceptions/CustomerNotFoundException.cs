using System.Net;

namespace EBankAppSample.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public CustomerNotFoundException(string message) : base(message)
        {
            Message = message;
            StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
