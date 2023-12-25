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
    public class SpecifiedCategoryRepository : GenericRepository<SpecifiedCategory>, ISpecifiedCategoryRepository
    {
        public SpecifiedCategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<SpecifiedCategory?> GetSpecifiedCategoryByName(string name)
        {
           SpecifiedCategory? spCat = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
            return spCat;
        }
    }
}
