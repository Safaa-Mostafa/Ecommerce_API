namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetByIdAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncWithIncludes(ISpecification<T> spec);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
