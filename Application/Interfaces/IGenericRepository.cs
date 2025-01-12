namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncWithIncludes(ISpecification<T> spec);
        Task AddAsync(T entity);
        T Update(T entity);
        Task DeleteAsync(int id);
    }
}
