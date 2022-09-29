namespace Services.MedicalCenter.Contracts
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T?> GetItemAsync(int id);
        Task<T> SaveItemAsync(T entity);
        Task UpdateItemAsync(T entity);
        Task DeleteItemAsync(int id);
    }
}
