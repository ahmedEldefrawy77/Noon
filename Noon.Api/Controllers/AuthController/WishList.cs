using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.Features.WishListFeatures.Requests.Commands;
using Noon.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishList : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishList(IMediator mediator )
        {
            _mediator = mediator;
        }
       
        [HttpPost, Authorize]
        public async Task<IActionResult> AddWishList(string Name)
        {
            BaseCommonResponse response = await _mediator.Send(new AddWishListToUserRequest { Name = Name });
            return Ok(response);
        }

        [HttpPost("AddProduct"), Authorize]
        public async Task<IActionResult> AddProductToWishList(Guid ProductId)
        {
            BaseCommonResponse response = await _mediator.Send(new AddProductToWishListRequest {PrdId = ProductId });
            return Ok(response);
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteProduct(Guid wishListId, Guid productId)
        {
            BaseCommonResponse response = await _mediator.Send(new DeleteProductFromWishListRequest { productId = productId,wishListId = wishListId });
            return Ok(response);
        }

    }
}
