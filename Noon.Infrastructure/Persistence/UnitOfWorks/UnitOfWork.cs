using Microsoft.EntityFrameworkCore;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Domain.Persistence.IRepository;
using Noon.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository? _userRepository;
        private IProductRepository? _productRepository;
        private IBrandRepository?  _brandRepository;
        private ICategoryRepository? _categoryRepository;
        private ISpecifiedCategoryRepository? _specifiedCategoryRepository;
        private IMoneyRepository? _moneyRepository;
        private IWishListRepository? _wishListRepository;
        private IWishListProductRepository? _wishListProductRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_context);
 
        public IProductRepository ProductRepostiory =>
             _productRepository ??= new ProductRepository(_context,_brandRepository!,_specifiedCategoryRepository!,_categoryRepository!);

        public IBrandRepository BrandRepository =>
            _brandRepository ??= new BrandRepository(_context);

        public ICategoryRepository CategoryRepository => 
            _categoryRepository ??= new CategoryRepository(_context);

        public ISpecifiedCategoryRepository SpecificCategoryRepository 
            => _specifiedCategoryRepository ??= new SpecifiedCategoryRepository(_context);

        public IMoneyRepository MoneyRepository 
            => _moneyRepository ??= new MoneyRepository(_context);

        public IWishListRepository WishListRepository
            => _wishListRepository ??= new WishListRepository(_context);

        public IWishListProductRepository WishListProductRepository 
            => _wishListProductRepository ??= new WishListProductRepository(_context,_wishListRepository!);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
