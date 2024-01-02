using MediatR;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.DTOs.Record.Brand;
using Noon.Application.Features.BrandFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandRecord record)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            return Ok(response = await _mediator.Send(new CreateBrandRequest { CreateBrandRecord = record }));
        }

        
    }
}
