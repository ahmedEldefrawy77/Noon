using Microsoft.EntityFrameworkCore;
using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        

        public async Task<Category?> SearchCategoryByName(string categoryName)
        {
            
            Category? category = await  _dbSet.FirstOrDefaultAsync(e => e.Name == categoryName);
            
            return category;
        }
    }
}
