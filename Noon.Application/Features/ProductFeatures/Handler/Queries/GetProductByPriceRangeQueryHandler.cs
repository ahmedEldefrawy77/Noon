using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
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
    public class GetProductByPriceRangeQueryHandler : IRequestHandler<GetProductsByPriceRangeRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByPriceRangeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(GetProductsByPriceRangeRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if (request.request == null || request.request.Name == string.Empty || request.request.MinPrice == null || request.request.MaxPrice == null || request.request.MaxPrice <= 0)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "please check your entry data";
                return response;
            }
            
                IReadOnlyList<Product> productsWithPriceRange = await _unitOfWork.ProductRepostiory.GetProductsByPriceRange(request.request.Name, request.request.MinPrice, request.request.MaxPrice);
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = productsWithPriceRange;
            return response;
        }
    }
}
