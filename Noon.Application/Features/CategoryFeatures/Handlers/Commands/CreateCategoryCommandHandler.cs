using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Exceptions;
using Noon.Application.Features.CategoryFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.CategoryFeatures.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommonResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
           BaseCommonResponse response = new BaseCommonResponse();
            if(request.Name == null)
            {
                
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Category Name couldnot be null";
                return response;

            }
            Category category = new Category();
            category.Name = request.Name;
            Category createdCategory  = await _unitOfWork.CategoryRepository.AddAsync(category);

            response.Id = createdCategory.Id;
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = createdCategory;

             return response;
        }
    }
}
