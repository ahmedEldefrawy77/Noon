using MediatR;
using Noon.Application.Contracts.Identity;
using Noon.Application.DTOs.Record;
using Noon.Application.Features.UserFeatures.Requests.Queries;
using Noon.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Handlers.Queries
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, BaseCommonResponse>
    {
        private readonly IAuthServices _service;

        public LoginUserHandler(IAuthServices service)
        {
            _service = service;
        }
        public async Task<BaseCommonResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.userRequest.Email == string.Empty || request.userRequest?.Password ==null)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Login Faild : Eaither Email or Password isnot provided";
                return response;
            }
            response = await _service.Login(request.userRequest);
            return response;
        }
    }
}
