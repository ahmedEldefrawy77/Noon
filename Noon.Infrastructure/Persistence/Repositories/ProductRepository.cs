using Microsoft.EntityFrameworkCore;
using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : BaseSettingRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public  Task<IReadOnlyList<Product>> GetProductByBrand(string brandName)
        {
          // List<Product> list = new List<Product>();
          //  IReadOnlyList<Product> myList = list.AsReadOnly();


          //  Guid brandId = _context.Brands
          //      .Where(e=> e.Name == brandName)
          //      .Select(e=>e.Id)
          //      .FirstOrDefault();
          //  if(brandId == Guid.Empty)
          //  {
          //      return myList;
          //  }

          ////List<Product> prdList = await  _context.Products
          ////   .Where(product => product.BrandId == brandId).ToListAsync();

          //  IReadOnlyList<Product> readOnlyProducts = prdList.AsReadOnly();
          //  return readOnlyProducts;
          throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Product>> GetProductBySpecifiedCategory(string specifiedCategoryName)
        {
            List<Product> list = new List<Product>();
            IReadOnlyList<Product> myList = list.AsReadOnly();


            Guid scId = _context.SpecifiedCategories
                .Where(e => e.Name == specifiedCategoryName)
                .Select(e => e.Id)
                .FirstOrDefault();
            if (scId == Guid.Empty)
            {
                return myList;
            }

            List<Product> prdList = await _context.Products
               .Where(product => product.SpecifiedCategoryId == scId).ToListAsync();

            IReadOnlyList<Product> readOnlyProducts = prdList.AsReadOnly();
            return readOnlyProducts;
        }

        public async Task<IReadOnlyList<Product>> GetProductsByPriceRange(string prdName, decimal minPrice, decimal maxPrice)
        {
            List<Product> prdList = await _context.Products
                .Where(e => e.Name == prdName && e.Price != null && e.Price.Amount >= minPrice && e.Price.Amount <= maxPrice)
                .ToListAsync();

            IReadOnlyList<Product> readOnlyPrdList = prdList.AsReadOnly();
            return readOnlyPrdList;
        }
    }
}
