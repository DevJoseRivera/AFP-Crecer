namespace Library.Clients.Contracts
{
    public interface ISingleResponse<T> : IResponse
    {
        T Item { get; set; }
    }
}
