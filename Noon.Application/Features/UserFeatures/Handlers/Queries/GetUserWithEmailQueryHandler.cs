using AutoMapper;
using MediatR;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.Exceptions;
using Noon.Application.Features.UserFeatures.Requests.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Handlers.Queries
{
    public class GetUserWithEmailQueryHandler : IRequestHandler<GetUserWithEmailRequest, BaseCommonResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserWithEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommonResponse> Handle(GetUserWithEmailRequest request, CancellationToken cancellationToken)
        {
            User? user  = await _userRepository.GetUserWithEmail(request.Email);
           
            if (user == null)
            {
                NotFoundException ex = new("User", request.Email);
                BaseCommonResponse badRequestResponse = new BaseCommonResponse()
                {
                    Status = false,
                    ResponseNumber = 500,
                    Response = $"Transaction Failed : {ex}"
               };
                return badRequestResponse;
            }
            UserDto userDto = _mapper.Map<UserDto>(user);
            BaseCommonResponse response = new()
            {
                Status = true,
                ResponseNumber = 200,
                Response = $"Transaction Succeded : {userDto}"
            };
            return response;
             
        }
    }
}
