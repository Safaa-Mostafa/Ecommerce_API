using Application.Interfaces;
using Domain.Entities.common;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;

namespace Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<T>> GetAllAsyncWithIncludes(ISpecification<T> spec)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in spec.Includes)
            {
                query = query.Include(include);

            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public  T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

    }
}
