using Microsoft.EntityFrameworkCore;
using Noon.Domain.Entities;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class WishListRepository : GenericRepository<WishList> , IWishListRepository
    {
        public WishListRepository(ApplicationDbContext context)  : base(context) { }

        public async Task ChangeWishListsDefaultStatuse(Guid id)
        {
            List<WishList> wishListFromDb = await Task.Run(()=>_dbSet.Where(e=>e.WishListUserId == id).ToList());
           
            foreach(var wish in wishListFromDb)
            {
                wish.Default = false;
               await UpdateAsync(wish);
            }
        }

        public async Task<IReadOnlyList<WishList>?> GetAllWishListForUser(Guid userId)
        {
            IReadOnlyList<WishList>? wishListforUser = await Task.Run(() => _dbSet.Where(e => e.WishListUserId == userId).ToListAsync());
            return wishListforUser;
        }

        public async Task<IReadOnlyList<WishList>> GetWishListWithName(string name, Guid UserId)
        {
            IReadOnlyList<WishList> wishList = await Task.Run(()=>_dbSet.Where(e=>e.WishListUserId == UserId && e.Name == name).ToListAsync()); 
           return wishList;
        }

      
    }
}
