using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Api.Controllers.BaseController;

using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.Record;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using System.Security.Claims;

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : BaseController<User>
    {
        
        private readonly IMediator _mediator;

        public UpdateController( IMediator mediator) 
        {
           
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> Update( UpdateUserDto userRequest)
        {
           
            BaseCommonResponse response = new BaseCommonResponse();
            Guid id = GetUserId();
            Unit unit = await _mediator.Send(new UpdateUserRequest { });
            response.Response = "User Updated Successfully";
            return Ok(response);
        }

    }
}
