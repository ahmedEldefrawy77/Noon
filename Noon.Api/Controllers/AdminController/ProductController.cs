using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.DTOs.Record.Product;
using Noon.Application.Features.ProductFeatures.Request.Commands;
using Noon.Application.Features.ProductFeatures.Request.Queries;
using Noon.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost, Authorize(Roles="Seller")]
        public async Task<IActionResult> CreatePoduct(CreateProductRecord uRequest)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            return Ok(response = await _mediator.Send(new CreateProductRequest { Productrecord = uRequest }));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductCategory(string Name)
        {
            BaseCommonResponse response = await _mediator.Send(new GetAllProductsForCategoryRequest { CategoryName = Name });
            return Ok();
        }

        [HttpGet("Brand")]
        public async Task<IActionResult> GetAllProductBrand(string Name)
        {
            BaseCommonResponse response = await _mediator.Send(new GetAllProductsWithBrandNameRequest { Name = Name });
            return Ok(response);
        }

        [HttpGet("SpecifiedCategory")]
        public async Task<IActionResult> GetAllProductSpecifiedCategory(string Name)
        {
            BaseCommonResponse response = await _mediator.Send(new GetAllProductWithSpecifiedCategoryNameRequest {Name = Name});
            return Ok(response);
        }
        [HttpGet("PriceRange")]
        public async Task<IActionResult> GetProductByPriceRange(ProductPricingRecord urequest)
        {
            BaseCommonResponse response = await _mediator.Send(new GetProductsByPriceRangeRequest { request = urequest});
            return Ok(response);
        }
    }
}
