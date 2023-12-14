using AutoMapper;
using MediatR;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.DTOs.UserDtos;
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
    public class GetUserListQueryHandler : IRequestHandler<GetUserListRequest, BaseCommonResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommonResponse> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<User> users = await _userRepository.GetAllAsync();
           List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
            BaseCommonResponse response = new()
            {
                Status = true,
                ResponseNumber = 200,
                Response = $"Transaction Succeded : {usersDto}"
            };
            return response;
        }
    }
}
