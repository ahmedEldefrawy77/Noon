using MediatR;
using Noon.Application.Contracts.Identity;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Handlers.Commands
{
    public  class RegisterUserCommandHandler : IRequestHandler<RegisterUserRequest, BaseCommonResponse>
    {
        private readonly IAuthServices _service;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IAuthServices service , IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        public async Task<BaseCommonResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
           BaseCommonResponse response = new BaseCommonResponse();
            if(request.UserRequest == null )
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "Request Can not be null : Register Mediator";
                return response;
            }

           return response = await _service.Register(request.UserRequest);
        }
    }
}
