using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.WishListFeatures.Requests.Commands;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.WishListFeatures.Handlers.Commands
{
    public class DeleteProductFromWishListCommandHandler : IRequestHandler<DeleteProductFromWishListRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductFromWishListCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommonResponse> Handle(DeleteProductFromWishListRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.productId == Guid.Empty)
            {
                response.Status = false;
                response.Response = "Eather the Product is already Deleted of Product Id is False";
                return response;
            }

            await _unitOfWork.WishListProductRepository.DeletewishListProduct(request.wishListId, request.productId);

            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Product Has been deleted Successfully";
            return response;
        }
    }
}
