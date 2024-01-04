using Microsoft.EntityFrameworkCore;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class WishListProductRepository : IWishListProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWishListRepository _wishListRepository;
        private readonly DbSet<WishListProducts> _dbSet;
        public WishListProductRepository(ApplicationDbContext context,IWishListRepository wishListRepository)
        {
            _context = context;
            _wishListRepository = wishListRepository;
            _dbSet = context.Set<WishListProducts>();
        }

        public  async Task AddWishListProduct(WishListProducts wishlistPrd)
        {
            await _dbSet.AddAsync(wishlistPrd);
            await _context.SaveChangesAsync();
        }

        public async Task DeletewishListProduct(Guid wishlistId, Guid productId)
        {
            IReadOnlyList<WishListProducts>? wishListProduct = await Task.Run(() => _dbSet.Where(e => e.WishListId == wishlistId && e.ProductId == productId).ToListAsync());
            if(wishListProduct != null || wishListProduct?.Count != 0) 
            {
                _context.RemoveRange(wishListProduct!);
                await _context.SaveChangesAsync();
            }
           
        }

        public async Task<IEnumerable<WishListProducts>> GetWishLisWithProductForUser(Guid id)
        {
           IReadOnlyList<WishList>? wishListlist = await _wishListRepository.GetAllWishListForUser(id);
            
            IEnumerable<WishListProducts> wishListProducts = new List<WishListProducts>();
            if(wishListlist != null)
            {
                foreach (var wishList in wishListlist)
                {
                    wishListProducts = await Task.Run(() => _dbSet.Where(e => e.WishListId == wishList.Id));
                }
            }
            
            return wishListProducts;
        }

        public async Task<bool> IsProductAddToWishList(Guid wishListid, Guid productid)
        {
           IReadOnlyList<WishListProducts>? wishListProduct= await Task.Run(()=>_dbSet.Where(e=> e.WishListId == wishListid && e.ProductId == productid).ToListAsync());
           if(wishListProduct?.Count != 0 )
           {
                return true;
           }
           return false;
        }
    }
}
