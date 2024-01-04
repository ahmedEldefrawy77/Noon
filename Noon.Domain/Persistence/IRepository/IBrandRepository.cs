using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IRepository
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<Brand?> GetBrandByName(string name);
        Task<Guid> GetBrandByIdByName(string brandName);
        Task<bool> IsBrandExistForCategory(Guid categoryId, string brandName);
       
    }
}
