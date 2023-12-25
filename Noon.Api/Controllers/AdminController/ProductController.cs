using MediatR;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.DTOs.Record.Product;
using Noon.Application.Features.ProductFeatures.Request.Commands;
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
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductRecord uRequest)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            return Ok(response = await _mediator.Send(new CreateProductRequest { Productrecord = uRequest }));
        }

    }
}
