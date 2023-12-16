using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Contracts.Persistence.IBaseRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> Exist(int id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
