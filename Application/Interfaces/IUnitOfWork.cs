using Domain.Entities.common;

namespace Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
