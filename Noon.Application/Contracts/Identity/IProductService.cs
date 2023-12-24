using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Application.DTOs.ProductDto;
using Noon.Application.DTOs.Record.Product;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Contracts.Identity
{
    public interface IProductService 
    {
        Task<BaseCommonResponse> CreateProduct(CreateProductDto prdRequest);
        Task<BaseCommonResponse> UpdateProduct(UpdateProductRecord updateRecord);
    }
}
