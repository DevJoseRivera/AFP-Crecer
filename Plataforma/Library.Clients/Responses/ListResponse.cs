using Library.Clients.Contracts;

namespace Library.Clients.Responses
{
    public class ListResponse<T> : Response, IListResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
    }
}
