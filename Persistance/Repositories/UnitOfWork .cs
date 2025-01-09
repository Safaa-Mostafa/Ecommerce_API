using Application.Interfaces;
using Domain.Entities.common;
using Persistance.Data;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
