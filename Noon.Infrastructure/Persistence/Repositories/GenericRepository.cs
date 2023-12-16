using Microsoft.EntityFrameworkCore;
using Noon.Application.Contracts.Persistence.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        protected DbSet<IEnumerable<T>> _entitiesDbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _dbSet = context.Set<T>();
            _entitiesDbSet = context.Set<IEnumerable<T>>();
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
              await Task.Run(()=> _context.Set<T>().Remove(entity));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWithIdAsync(Guid id)
        {
            T? entity = await GetAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await Task.Run(() => _context.Set<T>().Remove(entity));
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
          return await _context.Set<T>().ToListAsync();
            
        }

        public async Task<T?> GetAsync(Guid id) 
        {
           return await _context.Set<T>().FindAsync(id);
           
        }

        public async Task UpdateAsync(T entity)
        {
           await Task.Run(()=> _context.Update(entity));
            await _context.SaveChangesAsync();
        }


    }
}
