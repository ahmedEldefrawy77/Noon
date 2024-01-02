using MediatR;
using Microsoft.AspNetCore.Http;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.WishListFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.WishListFeatures.Handlers.Commands
{
    public class AddWishListToUserCommandHandler : IRequestHandler<AddWishListToUserRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;

        public AddWishListToUserCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }

        public async Task<BaseCommonResponse> Handle(AddWishListToUserRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            var context = _accessor.HttpContext;

            Guid userId = GetUserId(context); 
            if(userId == Guid.Empty) 
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Invalid Token, Id Cannot be Empty";
                return response;
            }

            IReadOnlyList<WishList> wishListFromDb = await _unitOfWork.WishListRepository.GetWishListWithName(request.Name, userId);
            if(wishListFromDb.Count != 0)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Wish List name is already exists please choose another Name";
                return response;
            }

            WishList wishList = new WishList();
            wishList.WishListUserId = userId;
            wishList.Name = request.Name;
            wishList.Default = true;

            await _unitOfWork.WishListRepository.ChangeWishListsDefaultStatuse(userId);

            WishList? createdWL = await _unitOfWork.WishListRepository.AddAsync(wishList);

            response.Status = true;
            response.ResponseNumber = 200; 
            response.Response = createdWL;
            return response;
        }
        private Guid GetUserId(HttpContext? context)
        {
            if (context == null)
                throw new ArgumentNullException("Invalid Context Operation");

            var claimid = context.User.FindFirst("Id")?? new ("Id",  Guid.Empty.ToString());
            return new(claimid.Value);
        }
    }
}
