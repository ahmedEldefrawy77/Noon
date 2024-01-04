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
    public class AddProductToWishListCommandHandler : IRequestHandler<AddProductToWishListRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;

        public AddProductToWishListCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }
        public async Task<BaseCommonResponse> Handle(AddProductToWishListRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            var context = _accessor.HttpContext;
            Guid userId = GetUserIdFromClaims(context);

           
            if(  userId == Guid.Empty || request.PrdId == Guid.Empty ) {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Eather token is invalid or Product id is Empty";
                return response;

            }

            IReadOnlyList<WishList>? WishListForUserFromDb = await _unitOfWork.WishListRepository.GetAllWishListForUser(userId);
            WishListProducts wLPrd = new WishListProducts();

            //Check if the User Dosenot have any wishList Created so I Made one with name default 

            if ( WishListForUserFromDb?.Count == 0) 
            {
                WishList wishList = new WishList();
                wishList.Name = "default";
                wishList.Default = true;
                wishList.WishListUserId = userId;

                WishList createdWL =  await _unitOfWork.WishListRepository.AddAsync(wishList);
               
                wLPrd.WishListId = createdWL.Id;
                wLPrd.ProductId = request.PrdId;
                await _unitOfWork.WishListProductRepository.AddWishListProduct(wLPrd);

                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = "Product Has benn Added Successfully to your Wish List";
                return response;
            }

            //if the user has already wishList created so i check which one of them with statuse default for the product to be added in it 
            //if the Product is already exist in this Wishlist i wount add it again unless it is the same product with another id with another Specification 
            foreach(var Wish in WishListForUserFromDb)
            {
                if(Wish.Default == true)
                {
                    if(!await _unitOfWork.WishListProductRepository.IsProductAddToWishList(Wish.Id, request.PrdId))
                    {
                        wLPrd.ProductId = request.PrdId;
                        wLPrd.WishListId = Wish.Id;

                        await _unitOfWork.WishListProductRepository.AddWishListProduct(wLPrd);
                    }
                    else
                    {
                        response.Status = false;
                        response.Response = "this Product is Already added to your Wish list";
                        return response;
                    }
                   
                }
            }
            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Product Has been Successfully Added to your Wish List";
            return response;

        }
        private Guid GetUserIdFromClaims(HttpContext? context)
        {
            if (context == null)
             throw new ArgumentNullException("Invalid Operation");

            var userid = context.User.FindFirst("Id") ?? new("Id" ,Guid.Empty.ToString());
            return new(userid.Value);
        }
    }
}
