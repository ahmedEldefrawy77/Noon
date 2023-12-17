using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Api.Controllers.BaseController;
using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.Record;
using Noon.Application.Responses;
using Noon.Domain.Entities;

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController  : BaseController<User>
    {
        private readonly IAuthServices _service;

        public LoginController(IAuthServices service) : base(service)
        {
          _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest loginRequest)
        {
            BaseCommonResponse response = await _service.Login(loginRequest);
            if(response.Token != null)
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
