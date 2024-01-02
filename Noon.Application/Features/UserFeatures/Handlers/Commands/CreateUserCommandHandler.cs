using AutoMapper;
using FluentValidation;
using MediatR;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.DTOs.UserDtos.validator;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork,IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<BaseCommonResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            RegiseterUserDtoValidator validator = new RegiseterUserDtoValidator(_userRepository);


            var validationResult = await validator.ValidateAsync(request.RegisterUserDto);
            if ( validationResult.IsValid == false)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = validationResult.Errors.Select(p=>p.ErrorMessage).ToList();
            }
            else
            {
                request.RegisterUserDto.Password = BCrypt.Net.BCrypt.HashPassword(request.RegisterUserDto.Password);

                User userDtoToUser = _mapper.Map<User>(request.RegisterUserDto);

                await _unitOfWork.UserRepository.AddAsync(userDtoToUser);
               

                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = userDtoToUser;
                response.Id = userDtoToUser.Id;
            }
            return response;
        }
        
    }
}
