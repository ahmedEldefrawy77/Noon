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
    public interface IProductRepository : IBaseSettinRepository<Product>
    {

        //defining specific Methods of retreving the product along with Methods that Basic Method implemented in GenericRepository and BaseSetting Repository
        //meant to be used in 
        Task<IReadOnlyList<Product>> GetProductByBrand(string brandName);
        Task<IReadOnlyList<Product>> GetProductBySpecifiedCategory(string specifiedCategoryName);
        Task<IReadOnlyList<Product>> GetProductsByPriceRange(string prdName,decimal minPrice, decimal maxPrice);
        //Task<Product> AddProductReview(Guid productId, ProductReview review);
    }
}
