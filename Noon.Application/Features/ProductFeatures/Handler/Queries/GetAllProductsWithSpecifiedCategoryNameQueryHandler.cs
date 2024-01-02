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
    public class GetAllProductsWithSpecifiedCategoryNameQueryHandler : IRequestHandler<GetAllProductWithSpecifiedCategoryNameRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsWithSpecifiedCategoryNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(GetAllProductWithSpecifiedCategoryNameRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if (request.Name == string.Empty)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Name Cannot be null";
                return response;

            }
            SpecifiedCategory? specCategoryFromDb = await _unitOfWork.SpecificCategoryRepository.GetSpecifiedCategoryByName(request.Name);
            if (specCategoryFromDb == null)
            {
                NotFoundException ex = new("SpecifiedCategory", request.Name);
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = ex;
                return response;
            }
            IReadOnlyList<Product> Products = await _unitOfWork.ProductRepostiory.GetProductBySpecifiedCategory(request.Name);
            if (Products.Count == 0)
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
