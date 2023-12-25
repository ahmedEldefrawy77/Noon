using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Contracts.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepostiory {  get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISpecifiedCategoryRepository SpecificCategoryRepository { get; }
        IMoneyRepository MoneyRepository { get; }
    }
}
