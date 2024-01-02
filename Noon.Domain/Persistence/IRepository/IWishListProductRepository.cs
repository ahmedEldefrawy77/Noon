using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IRepository
{
    public interface IWishListProductRepository 
    {
        Task<IEnumerable<WishListProducts>> GetWishLisWithProductForUser(Guid id);
        Task AddWishListProduct(WishListProducts wishlstPrd);
        Task<bool> IsProductAddToWishList(Guid wishListid, Guid productid);
        Task DeletewishListProduct(Guid wishlistId, Guid productId);
    }
}
