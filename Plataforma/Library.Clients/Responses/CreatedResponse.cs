using Library.Clients.Contracts;

namespace Library.Clients.Responses
{
    public class CreatedResponse<T> : Response, ICreatedResponse<T?>
    {
        public T? Id { get; set; }
    }
}
