﻿using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IRepository
{
    public interface ISpecifiedCategoryRepository : IGenericRepository<SpecifiedCategory>
    {
        Task<IEnumerable<Brand>> GetSpecifiedCategoryByName(string name);
    }
}
