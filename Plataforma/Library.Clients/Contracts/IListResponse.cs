namespace Library.Clients.Contracts
{
    public interface IListResponse<T> : IResponse
    {
        IEnumerable<T>? Items { get; set; }
    }
}
