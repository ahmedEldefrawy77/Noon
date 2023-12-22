using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Noon.Api.Controllers.BaseController;
using Noon.Application.Contracts.Identity;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Tokens;

//namespace Noon.Api.Controllers.AuthController
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LogoutController : BaseController<User>
//    {
//        private readonly IAuthServices _service;

//        public LogoutController(IAuthServices service) : base(service) 
//        {
//            _service = service;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Logout(Token? token)
//        {
//             BaseCommonResponse response = new BaseCommonResponse();
//            string refreshToken = HttpContext.Request.Cookies["RefreshToken"] ?? string.Empty;

//            if (token != null && refreshToken != null)
//                refreshToken = token.RefreshToken;

//           response = await _service.Logout(refreshToken);
//            return Ok(response);
//        }
//    }
//}
