using AutoMapper;
using MediatR;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.DTOs.Validator;
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
            CreateUserValidator validator = new CreateUserValidator(_userRepository);

            if(request.CreateUserDto == null)
                throw new ArgumentNullException(nameof(request));


            var validationResult = await validator.ValidateAsync(request.CreateUserDto);
            if ( validationResult.IsValid == false)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = validationResult.Errors.Select(p=>p.ErrorMessage).ToList();
            }
            else
            {
                request.CreateUserDto.Password = BCrypt.Net.BCrypt.HashPassword(request.CreateUserDto.Password);
                User userDtoToUser = _mapper.Map<User>(request.CreateUserDto);
                await _unitOfWork.UserRepository.AddAsync(userDtoToUser);
                await _unitOfWork.Save();

                response.Status = true;
                response.ResponseNumber = 200;
                response.Response = "User Created";
                response.Id = userDtoToUser.Id;
            }
            return response;
        }
        
    }
}
