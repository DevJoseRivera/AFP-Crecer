namespace Library.Clients.Contracts
{
    public interface IResponse
    {
        bool? IsFailed { get; set; }
        string? Message { get; set; }
    }
}
