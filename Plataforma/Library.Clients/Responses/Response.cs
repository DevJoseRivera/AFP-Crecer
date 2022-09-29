using Library.Clients.Contracts;

namespace Library.Clients.Responses
{
    public class Response : IResponse
    {
        public bool? IsFailed { get; set; }
        public string? Message { get; set; }
    }
}
