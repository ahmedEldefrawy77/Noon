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
    public class GetAllProductsForCategoryCommandHandler : IRequestHandler<GetAllProductsForCategoryRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsForCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(GetAllProductsForCategoryRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if (request.CategoryName == string.Empty)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Category Name Cannot be null";
                return response;

            }
            Category? categoryfromDb = await _unitOfWork.CategoryRepository.SearchCategoryByName(request.CategoryName);
            if (categoryfromDb == null)
            {
                NotFoundException ex = new("Category Name", request.CategoryName);
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = ex;
                return response;
            }
            IReadOnlyList<Product> Products = await _unitOfWork.ProductRepostiory.GetAllProductsByCategoryName(request.CategoryName);
            if (Products.Count == 0)
            {
                NotFoundException ex = new("Products", request.CategoryName);
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
