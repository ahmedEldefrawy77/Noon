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
    public class GetUserWithIdQueryHandler : IRequestHandler<GetUserWithIdRequest, BaseCommonResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserWithIdQueryHandler(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommonResponse> Handle(GetUserWithIdRequest request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                NotFoundException ex = new("User" ,  request.Id);
                BaseCommonResponse errorResponse = new BaseCommonResponse()
                {
                    Status = false,
                    ResponseNumber = 500,
                    Response = $"Transaction Failed : {ex}"
                };
                return errorResponse;
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
