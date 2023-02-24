using eshopWebAPI.Data;
using eshopWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eshopWebAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(string? Id)
        {
            var entity = await GetAsync(Id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string? Id)
        {
            var entity = await GetAsync(Id);
            return entity != null;
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(string? Id)
        {
            if (Id is null)
            {
                return null;
            }
            var entity = await _context.Set<T>().FindAsync(Id);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
