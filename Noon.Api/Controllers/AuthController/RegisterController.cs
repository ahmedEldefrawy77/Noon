using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Api.Controllers.BaseController;
using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Tokens;

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController<User>
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto userRequest)
        {
            BaseCommonResponse response = await _mediator.Send(new RegisterUserRequest { UserRequest = userRequest });
            if (response.Token != null && response.Token.AccessToken != null && response.Token.RefreshToken != null)
            {
                SetCookie("AccessToken",
                response.Token.AccessToken,
                response.Token.AccessTokenExDate);

                SetCookie("RefreshToken",
                      response.Token.RefreshToken,
                response.Token.RefreshTokenExDate);

                return Ok(response);
            }
            return Ok(response);
            
           
        }
    }
}
