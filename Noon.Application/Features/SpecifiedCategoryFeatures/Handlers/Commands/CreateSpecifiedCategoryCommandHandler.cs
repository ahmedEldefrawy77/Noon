using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.SpecifiedCategoryFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.SpecifiedCategoryFeatures.Handlers.Commands
{
    public class CreateSpecifiedCategoryCommandHandler : IRequestHandler<CreateSpecifiedCategoryRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSpecifiedCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(CreateSpecifiedCategoryRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.request == null || request.request.SpecifiedName == string.Empty || request.request.CategoryName == string.Empty )
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Invalid Request: Request Cannot be Null";
                return response;
            }
            //check if the SpecCat Name is already exist
            SpecifiedCategory? specCatFromDb = await _unitOfWork.SpecificCategoryRepository.GetSpecifiedCategoryByName(request.request.SpecifiedName);
            if( specCatFromDb != null )
            {
                response.Status = false;
                response.Response = "Specified Category Name is already Exist: choose another name";
                return response;
            }
            Category? categoryFromDb = await _unitOfWork.CategoryRepository.SearchCategoryByName(request.request.CategoryName);
            if(categoryFromDb == null)
            {
                response.Status = false;
                response.Response = "there is no Category with Given Name please ensure that the Category Name is right";
                return response;
            }
            SpecifiedCategory? spCat = new SpecifiedCategory();
           
            spCat.CategoryId = categoryFromDb.Id;
            spCat.Name = request.request.SpecifiedName;
            
            SpecifiedCategory createdSpCat = await _unitOfWork.SpecificCategoryRepository.AddAsync(spCat);
            response.Id = createdSpCat.Id;
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Specified Category Created Successfully";

            return response;
        }
    }
}
