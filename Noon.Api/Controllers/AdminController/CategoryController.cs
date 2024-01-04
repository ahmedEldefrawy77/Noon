using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.Features.CategoryFeatures.Requests.Commands;
using Noon.Application.Responses;

namespace Noon.Api.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost, Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            return Ok(response = await _mediator.Send(new CreateCategoryRequest { Name = categoryName }));
        }
    }
}
