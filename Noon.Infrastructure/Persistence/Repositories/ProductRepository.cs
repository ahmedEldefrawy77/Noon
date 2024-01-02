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
        private readonly IBrandRepository _brandRepository;
        private readonly ISpecifiedCategoryRepository _specRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository(ApplicationDbContext context,
            IBrandRepository brandRepository,ISpecifiedCategoryRepository specRepository,
            ICategoryRepository categoryRepository) : base(context)
        {
           _brandRepository = brandRepository;
            _specRepository = specRepository;
            _categoryRepository = categoryRepository;
        }

        public  async Task<IReadOnlyList<Product>> GetAllProductsByCategoryName(string Name)
        {
            List<Product> list = new List<Product>();
            IReadOnlyList<Product> myList = list.AsReadOnly();


            Guid categoryId = await _categoryRepository.GetCategoryIdByName(Name);
            if (categoryId== Guid.Empty)
            {
                return myList;
            }

            List<Product> AllProductForCategory = new List<Product>();

            List<Guid> specCategories = await _specRepository.GetAllSpecifiedCategoryIdsWithCategoryId(categoryId);

            foreach(Guid specId in specCategories)
            {
               AllProductForCategory = await _dbSet.Where(e=>e.SpecifiedCategoryId ==  specId).ToListAsync();
            }

            IReadOnlyList<Product> readOnlyProducts = AllProductForCategory.AsReadOnly();
            return readOnlyProducts;
        }

        public async  Task<IReadOnlyList<Product>> GetProductByBrand(string brandName)
        {
            List<Product> list = new List<Product>();
            IReadOnlyList<Product> myList = list.AsReadOnly();


            Guid brandId = await _brandRepository.GetBrandByIdByName(brandName);
            if (brandId == Guid.Empty)
            {
                return myList;
            }

            List<Product> prdList = await _context.Products
               .Where(product => product.BrandId == brandId).ToListAsync();

            IReadOnlyList<Product> readOnlyProducts = prdList.AsReadOnly();
            return readOnlyProducts;
           
        }

        public async Task<IReadOnlyList<Product>> GetProductBySpecifiedCategory(string specifiedCategoryName)
        {
            List<Product> list = new List<Product>();
            IReadOnlyList<Product> myList = list.AsReadOnly();


            Guid scId = await _specRepository.GetSpecifiedCategoryIdByName(specifiedCategoryName);
            if (scId == Guid.Empty)
            {
                return myList;
            }

            List<Product> prdList = await _context.Products
               .Where(product => product.SpecifiedCategoryId == scId).ToListAsync();

            IReadOnlyList<Product> readOnlyProducts = prdList.AsReadOnly();
            return readOnlyProducts;
        }

        public async Task<IReadOnlyList<Product>> GetProductsByPriceRange(string prdName, decimal? minPrice, decimal? maxPrice)
        {
            List<Product> prdList = await _context.Products
                .Where(e => e.Name == prdName && e.Price != null && e.Price.Amount >= minPrice && e.Price.Amount <= maxPrice)
                .ToListAsync();

            IReadOnlyList<Product> readOnlyPrdList = prdList.AsReadOnly();
            return readOnlyPrdList;
        }
    }
}
