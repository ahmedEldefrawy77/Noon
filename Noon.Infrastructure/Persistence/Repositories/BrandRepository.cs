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
        

        public async  Task<IEnumerable<Brand>> GetBrandByName(string name)
        {
            IEnumerable<Brand> list = new List<Brand>();

            return list = await Task.Run(() => _dbSet.Where(e => e.Name == name).ToListAsync());
            
        }
    }
}
