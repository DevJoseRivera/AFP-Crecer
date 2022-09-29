namespace Library.Clients.Contracts
{
    public interface ICreatedResponse<T> : IResponse
    {
        T Id { get; set; }
    }
}
