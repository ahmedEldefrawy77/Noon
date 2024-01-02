using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.BrandFeatures.Requests.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.BrandFeatures.Handlers.Queries
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(GetAllBrandRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            IReadOnlyList<Brand> brands = await _unitOfWork.BrandRepository.GetAllAsync();
            if (brands == null || brands.Count == 0)
            {
                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = "there is no Brand has been created yet";
                return response;
            }
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = brands;
            return response;
        }
    }
}
