using Domain.Entities.common;

namespace Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
