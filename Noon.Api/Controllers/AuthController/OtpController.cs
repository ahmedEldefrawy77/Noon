using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Noon.Application.Features.UserFeatures.Handlers.Queries;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Application.Features.UserFeatures.Requests.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TemporarilyAccessOptions _temporarilyAccessOptions;

        public OtpController(IMediator mediator, IOptions<TemporarilyAccessOptions> temporarilyAccessOptions)
        {
            _mediator = mediator;
            _temporarilyAccessOptions = temporarilyAccessOptions.Value;
        }
        [HttpPost]
        public async Task<IActionResult> SendOtp(string email)
        {
            BaseCommonResponse response = await _mediator.Send(new GenerateUserOtpRequest { Email = email });
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> CheckOtp(string email, int otp)
        {
            BaseCommonResponse response = await _mediator.Send(new CheckUserOtpRequest { email = email, otp = otp });
            if(response.Status == true)
            {
                SetCookie("AccessToken",
               response.Response,
               DateTime.UtcNow.AddMinutes(_temporarilyAccessOptions.ExpireTimeInMintes));
                return Ok(response);
            }

            return BadRequest(response);
        }
        [HttpPost("ChangePassword"), Authorize(Roles="Temporarily")]
        public async Task<IActionResult> ChangePassword(string newPassword)
        {
            BaseCommonResponse response = await _mediator.Send(new UpdateUserPasswordOtpRequest { newPassword = newPassword});
            return Ok(response);
        }
        private void SetCookie(string name, string value, DateTime expireTime)
           => Response.Cookies.Append(name, value
              , new CookieOptions()
              {
                  HttpOnly = true,
                  Expires = expireTime
              });
    }
}
