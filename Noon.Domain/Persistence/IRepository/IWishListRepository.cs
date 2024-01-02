using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IRepository
{
    public interface IWishListRepository : IGenericRepository<WishList>
    {
        Task<IReadOnlyList<WishList>> GetWishListWithName(string name, Guid UserId);
        Task ChangeWishListsDefaultStatuse(Guid id);
        Task<IReadOnlyList<WishList>?> GetAllWishListForUser(Guid userId);
        
   
    }
}
