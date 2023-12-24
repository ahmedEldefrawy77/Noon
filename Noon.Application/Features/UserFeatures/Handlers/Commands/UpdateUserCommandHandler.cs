using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Noon.Application.Contracts.Identity;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, BaseCommonResponse>
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        private readonly IAuthServices _service;

        public UpdateUserCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,  IHttpContextAccessor accessor,IAuthServices service)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = accessor;
          _service = service;
        }
        public  async Task<BaseCommonResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
           if(request.UserRequest == null)
                throw new ArgumentNullException(nameof(request.UserRequest) + "cannot be Null");

            var context = _accessor?.HttpContext;
            Guid id = GetUserIdFromClaims(context);

            User? userFromDb = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if(userFromDb == null)
                throw new ArgumentNullException(nameof(userFromDb) + "Invalid Token");


            if (request.UserRequest.FirstName != null)
            {
                userFromDb.FirstName = request.UserRequest.FirstName;
            }
            if (request.UserRequest.LastName != null)
            {
                userFromDb.LastName = request.UserRequest.LastName;
            }
            if (request.UserRequest.Email != null)
            {
                userFromDb.Email = request.UserRequest.Email;
            }
            if (request.UserRequest.PhoneNumber != null)
            {
                userFromDb.PhoneNumber = request.UserRequest.PhoneNumber;
            }

            BaseCommonResponse response =  await _service.Update(userFromDb);
            response.Response = Unit.Value;
            return  response;

        }
        private Guid GetUserIdFromClaims(HttpContext? context)
        {

            if (context == null)
                throw new InvalidOperationException("This operation requires an active HTTP context.");

            var claimsId = context.User.FindFirst("Id") ?? new("Id", Guid.Empty.ToString());

            return new(claimsId.Value);
        }
    }
}
