using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Tokens;

namespace Noon.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController<User>
    {
        private readonly IAuthServices _service;

        public RegisterController(IAuthServices service) : base(service) => _service = service;
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto userRequest)
        {
            BaseCommonResponse response = await _service.Register(userRequest);
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
            return Ok(response);
            
           
        }
    }
}
