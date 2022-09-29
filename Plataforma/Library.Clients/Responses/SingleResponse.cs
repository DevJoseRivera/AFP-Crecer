using Library.Clients.Contracts;

namespace Library.Clients.Responses
{
    public class SingleResponse<T> : Response, ISingleResponse<T?>
    {
        public T? Item { get; set; }
    }
}
