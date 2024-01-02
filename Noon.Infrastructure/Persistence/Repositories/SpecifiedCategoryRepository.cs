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

        public async Task<List<Guid>> GetAllSpecifiedCategoryIdsWithCategoryId(Guid categoryId)
        {
            List<Guid> specifiedCategoryNames = await _dbSet.Where(e=>e.CategoryId == categoryId).Select(e=>e.Id).ToListAsync();
 
            return specifiedCategoryNames;
        }

        public async Task<SpecifiedCategory?> GetSpecifiedCategoryByName(string name)
        {
           SpecifiedCategory? spCat = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
            return spCat;
        }

        public async Task<Guid> GetSpecifiedCategoryIdByName(string specName)
        {

            Guid id = await _dbSet.Where(e => e.Name == specName).Select(e => e.Id).FirstOrDefaultAsync();
            return id;
        }
    }
}
