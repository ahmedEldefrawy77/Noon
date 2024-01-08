using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.ProductFeatures.Request.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;
using Noon.Domain.IServices.IPicService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.ProductFeatures.Handler.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }
        public async Task<BaseCommonResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.id == Guid.Empty)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Product id cannot be Null";
                return response;
            }

            Product? productFromDb = await _unitOfWork.ProductRepostiory.GetProductById(request.id);
            if(productFromDb == null)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "invalid Product Id";
                return response;
            }

            await _unitOfWork.ProductRepostiory.DeleteAsync(productFromDb);
             _imageService.DeleteImage(request.id, "Product");

            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Product Deleted Successfully";
            return response;
        }
    }
}
