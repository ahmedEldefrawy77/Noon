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
        Task<IEnumerable<Brand>> GetBrandByName(string name);
       
    }
}
