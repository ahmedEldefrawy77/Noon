using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.SpecifiedCategoryFeatures.Requests.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.SpecifiedCategoryFeatures.Handlers.Queries
{
    public class GetAllSpecifiedCategoryQueryHandler : IRequestHandler<GetAllSpecifiedCategoryRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSpecifiedCategoryQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async  Task<BaseCommonResponse> Handle(GetAllSpecifiedCategoryRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            IReadOnlyList<SpecifiedCategory> specCategories = await _unitOfWork.SpecificCategoryRepository.GetAllAsync();
            if(specCategories == null || specCategories.Count == 0)
            {
                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = "there is no Specified category has been created yet";
                return response;
            }
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = specCategories;
            return response;
        }
    }
}
