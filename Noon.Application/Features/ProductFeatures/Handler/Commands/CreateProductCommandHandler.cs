using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.DTOs.MoneyDtos;
using Noon.Application.DTOs.ProductDto;
using Noon.Application.Features.ProductFeatures.Request.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.ImageResult;
using Noon.Domain.Entities.Products;
using Noon.Domain.IServices.IPicService;

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
        private readonly IImageService _imageService;
       

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
          
        }

        public async  Task<BaseCommonResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.Productrecord == null || request.Productrecord.Amount < 0 || request.Productrecord.Currency == string.Empty 
                || request.Productrecord.Quantity == 0 || request.Productrecord.BrandName == string.Empty
                || request.Productrecord.SpecifiedCategoryName ==string.Empty
                || request.Productrecord.Specifications == null|| request.Productrecord.Specifications.Count < 0 
                || request.Productrecord.ProductName == string.Empty || request.Productrecord.ProductDescription == string.Empty
                || request.Productrecord.CategoryName == string.Empty
                || request.Productrecord.ProductImage == null
                || request.Productrecord.ProductImage.Count == 0 )
            {
                response.Status = false;
                response.Response = "Invalid Request: Check your Entry Data";
                return response;
            }

            Brand? brandFromDb = await _unitOfWork.BrandRepository.GetBrandByName(request.Productrecord.BrandName);
            SpecifiedCategory? specCatFromDb = await _unitOfWork.SpecificCategoryRepository.GetSpecifiedCategoryByName(request.Productrecord.SpecifiedCategoryName);
            Category? categoryFromDb = await _unitOfWork.CategoryRepository.SearchCategoryByName(request.Productrecord.CategoryName);
            if (brandFromDb == null || specCatFromDb == null||categoryFromDb == null)
            {
                response.Status = false;
                response.Response = "Either Brand Name is false or Specified Category is false: Check the Name";
                return response;
            }
            //instantiate Product object
            Product? product = new Product();
            product.BrandId = brandFromDb.Id;
            product.SpecifiedCategoryId = specCatFromDb.Id;
            product.CategoryId = categoryFromDb.Id;
            product.Name = request.Productrecord.ProductName;
            product.Description = request.Productrecord.ProductDescription;
            product.Quantity = request.Productrecord.Quantity;
            product.Specifications = request.Productrecord.Specifications;
            Product? createdProduct = await _unitOfWork.ProductRepostiory.AddAsync(product);

            //instantiate Money Object for the Product
            Money? money = new Money();
            money.Amount = request.Productrecord.Amount;
            money.Currency = request.Productrecord.Currency;

            //relation Money & Product
            money.ProductId = createdProduct.Id;
            Money? createdMoneyEntity = await _unitOfWork.MoneyRepository.AddAsync(money);

            //mapping created Product to its Dto for outer layer
            ProductDto prdDto = _mapper.Map<ProductDto>(createdProduct);

            //Storing Product Image 
           ImageRecord imageResult =  await _imageService.SaveImage(request.Productrecord.ProductImage,createdProduct.Id);
            createdProduct.ImagePath = imageResult.imagePaths;

            //updating Product to store image paths
            await _unitOfWork.ProductRepostiory.UpdateAsync(createdProduct);

             //returning the final Result
            response.Status = true;
            response.Response = prdDto + $"{imageResult.passCount} Photo Uploaded Successfully and {imageResult.passFail} failed To upload";
            return response;
        }
       
    }
}
