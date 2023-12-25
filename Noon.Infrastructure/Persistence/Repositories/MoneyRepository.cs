using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class MoneyRepository : GenericRepository<Money> , IMoneyRepository
    {
        public MoneyRepository(ApplicationDbContext context) : base(context) { }

    }
}
