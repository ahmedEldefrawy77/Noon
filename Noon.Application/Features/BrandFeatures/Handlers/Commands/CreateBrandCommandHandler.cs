using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Exceptions;
using Noon.Application.Features.BrandFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.BrandFeatures.Handlers.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
          
            _unitOfWork = unitOfWork;
        }
        public async  Task<BaseCommonResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();

            //checking for Valid Entry Data
            if (request.CreateBrandRecord == null || request.CreateBrandRecord.CategoryName == null || request.CreateBrandRecord.BrandName == null)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Invalid Request";

                return response;
            }

            //check for Category
            Category? CategoryFromDb = await _unitOfWork.CategoryRepository.SearchCategoryByName(request.CreateBrandRecord.CategoryName);
            if (CategoryFromDb == null)
            {
                NotFoundException notfound = new NotFoundException("Category Name", request.CreateBrandRecord.CategoryName);
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = notfound;
                return response;
            }

            //check if Brand with the same given name is already created 
            Guid CategoryId = await _unitOfWork.CategoryRepository.GetCategoryIdByName(request.CreateBrandRecord.CategoryName);
            bool IsBrandExistedForCategory = await _unitOfWork.BrandRepository.IsBrandExistForCategory(CategoryId,request.CreateBrandRecord.BrandName);
            if(IsBrandExistedForCategory == true)
            {
                response.Status = false;
                response.Response = $"Brand Name{request.CreateBrandRecord.BrandName} is already exists for this Category {request.CreateBrandRecord.CategoryName}: choose another Name";
                return response;
            }
           
           
            Brand brand = new Brand();
            brand.Name=request.CreateBrandRecord.BrandName;
            brand.CategoryId = CategoryFromDb.Id;

            Brand addedBrand =  await _unitOfWork.BrandRepository.AddAsync(brand);

            response.Id = addedBrand.Id;
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Brand Created Successfully";

            return response;
        }
    }
}
