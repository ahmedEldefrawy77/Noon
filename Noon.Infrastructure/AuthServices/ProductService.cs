using MediatR;
using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.ProductDto;
using Noon.Application.DTOs.Record.Product;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IRepository;
using Noon.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.AuthServices
{
    public class ProductService : IProductService
    {

        //using the Mediator to send request for ProductRepository
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public Task<BaseCommonResponse> CreateProduct(CreateProductDto prdRequest)
        {
            throw new NotImplementedException();
        }

        public Task<BaseCommonResponse> UpdateProduct(UpdateProductRecord updateRecord)
        {
            throw new NotImplementedException();
        }
    }
}
