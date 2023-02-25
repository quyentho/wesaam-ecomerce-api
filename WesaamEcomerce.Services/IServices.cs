namespace WesaamEcomerce.Services
{
    public interface IServices<T> where T : class
    {
        ValueTask<List<T>?> GetAllAsync();
        ValueTask<T?> GetByIdAsync(int id);

        Task<int> CreateAsync(T entity);
        Task DeleteAsync(int id);


        Task UpdateAsync(T entity, int id);
    }
}
