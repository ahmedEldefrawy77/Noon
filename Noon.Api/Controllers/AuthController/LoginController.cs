using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Api.Controllers.BaseController;
using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.Record;
using Noon.Application.Features.UserFeatures.Requests.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities;

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController  : BaseController<User>
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest loginRequest)
        {
            BaseCommonResponse response = await _mediator.Send(new LoginUserRequest {userRequest = loginRequest});
            if(response.Token != null && response.Token.AccessToken != null && response.Token.RefreshToken != null)
            {
                SetCookie("AccessToken",
                    response.Token.AccessToken,
                    response.Token.AccessTokenExDate);

                SetCookie("RefreshToken",
                    response.Token.RefreshToken,
                    response.Token.RefreshTokenExDate);
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
