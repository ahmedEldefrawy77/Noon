using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Contracts.Persistence.IBaseRepository
{
    public interface IGenericRepository<T> where T : class
    {
       
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteWithIdAsync(Guid id);
        Task<T?> GetAsync(Guid id);
    }
}
