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
    public class BrandRepository : GenericRepository<Brand> , IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }
        

        public async  Task<Brand?> GetBrandByName(string name)
        {
           Brand? brand = new Brand();

            return brand = await  _dbSet.FirstOrDefaultAsync(e => e.Name == name);
            
        }
    }
}
