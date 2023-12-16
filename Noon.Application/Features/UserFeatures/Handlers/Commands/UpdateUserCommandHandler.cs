using AutoMapper;
using MediatR;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork,IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public  async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
           if(request.UpdateUserDto == null)
                throw new ArgumentNullException(nameof(request.UpdateUserDto) + "cannot be Null");

            User? userFromDb = await _unitOfWork.UserRepository.GetUserByIdAsync(request.UpdateUserDto.Id);
            if(userFromDb == null)
                throw new ArgumentNullException(nameof(userFromDb) + "something went wronge");

            _mapper.Map(request.UpdateUserDto, userFromDb);

            await _unitOfWork.UserRepository.UpdateAsync(userFromDb);
            
            return Unit.Value;

        }
    }
}
