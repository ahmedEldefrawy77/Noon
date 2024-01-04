using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.DTOs.Record.SpecifiedCategory;
using Noon.Application.Features.SpecifiedCategoryFeatures.Requests.Commands;
using Noon.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecifiedCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecifiedCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSpecifiedCategory( SpecifiedCategoryRecord urequest)
        {
            BaseCommonResponse response = await _mediator.Send(new CreateSpecifiedCategoryRequest { request = urequest });
            return Ok(response);
        }

      
    }
}
