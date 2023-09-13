using System.Net;

namespace EntityFrameworkCoreExample.DTO
{
    public class Response<T>
    {
        public T responseContent { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        
    }
}
