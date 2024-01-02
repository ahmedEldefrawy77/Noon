using AutoMapper;
using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.DTOs.MoneyDtos;
using Noon.Application.DTOs.ProductDto;
using Noon.Application.Features.ProductFeatures.Request.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.ProductFeatures.Handler.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest , BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<BaseCommonResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.Productrecord == null || request.Productrecord.Amount < 0 || request.Productrecord.Currency == string.Empty 
                || request.Productrecord.Quantity == 0 || request.Productrecord.BrandName == string.Empty
                || request.Productrecord.SpecifiedCategoryName ==string.Empty
                || request.Productrecord.Specifications == null|| request.Productrecord.Specifications.Count < 0 
                || request.Productrecord.ProductName == string.Empty || request.Productrecord.ProductDescription == string.Empty)
            {
                response.Status = false;
                response.Response = "Invalid Request: Check your Entry Data";
                return response;
            }

            Brand? brandFromDb = await _unitOfWork.BrandRepository.GetBrandByName(request.Productrecord.BrandName);
            SpecifiedCategory? SpecCatFromDb = await _unitOfWork.SpecificCategoryRepository.GetSpecifiedCategoryByName(request.Productrecord.SpecifiedCategoryName);
            if(brandFromDb == null || SpecCatFromDb == null)
            {
                response.Status = false;
                response.Response = "Eather Brand Name is false or Specified Category is false: Check the Name";
                return response;
            }

            Product? product = new Product();
            product.BrandId = brandFromDb.Id;
            product.SpecifiedCategoryId = SpecCatFromDb.Id;
            product.Name = request.Productrecord.ProductName;
            product.Description = request.Productrecord.ProductDescription;
            product.Quantity = request.Productrecord.Quantity;
            product.Specifications = request.Productrecord.Specifications;
            Product? createdProduct = await _unitOfWork.ProductRepostiory.AddAsync(product);

            Money? money = new Money();
            money.Amount = request.Productrecord.Amount;
            money.Currency = request.Productrecord.Currency;
            money.ProductId = createdProduct.Id;

            Money? createdMoneyEntity = await _unitOfWork.MoneyRepository.AddAsync(money);
            ProductDto prdDto = _mapper.Map<ProductDto>(createdProduct);

            response.Status = true;
            response.Response = prdDto;
            return response;
        }
    }
}
