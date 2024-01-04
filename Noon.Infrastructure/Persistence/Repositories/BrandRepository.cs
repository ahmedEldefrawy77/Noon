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
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Guid> GetBrandByIdByName(string brandName)
        {
            Guid id = await _dbSet.Where(e=>e.Name == brandName).Select(e=>e.Id).FirstOrDefaultAsync();
            return id;
        }

        public async  Task<Brand?> GetBrandByName(string name)
        {
           Brand? brand = new Brand();

            return brand = await  _dbSet.FirstOrDefaultAsync(e => e.Name == name);
            
        }

        public async Task<bool> IsBrandExistForCategory(Guid categoryId, string brandName)
        {
            Brand? brandForCategoryFromDb = await _dbSet.Where(e=>e.CategoryId == categoryId && e.Name == brandName).FirstOrDefaultAsync();
            if(brandForCategoryFromDb != null)
            {
                return true;
            }
            return false;
        }
    }
}
