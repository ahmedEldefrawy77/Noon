using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category?> SearchCategoryByName(string categoryName);
        
    }
}
