using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Exceptions;
using Noon.Application.Features.ProductFeatures.Request.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.ProductFeatures.Handler.Queries
{
    public class GetAllProductsWithBrandNameQueryHandler : IRequestHandler<GetAllProductsWithBrandNameRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsWithBrandNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(GetAllProductsWithBrandNameRequest request, CancellationToken cancellationToken)
        {
           BaseCommonResponse response = new BaseCommonResponse();
            if(request.Name == string.Empty)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Name Cannot be null";
                return response;

            }
            Brand? brandFromDb = await _unitOfWork.BrandRepository.GetBrandByName(request.Name);
            if(brandFromDb == null)
            {
                NotFoundException ex = new ("BrandName",request.Name);
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = ex;
                return response;
            }
            IReadOnlyList<Product> Products = await _unitOfWork.ProductRepostiory.GetProductByBrand(request.Name);
            if(Products.Count == 0)
            {
                NotFoundException ex = new("Products", request.Name);
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = ex;
                return response;
            }
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = Products;
            return response;
        }
    }
}
