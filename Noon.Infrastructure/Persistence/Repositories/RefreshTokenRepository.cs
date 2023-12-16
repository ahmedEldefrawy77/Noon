using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities.Tokens;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken> , IRefreshTokenRepository
    {
        

        public RefreshTokenRepository(ApplicationDbContext context) :base(context)
        {
            
        }
    }
}
