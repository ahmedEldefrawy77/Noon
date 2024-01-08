using BCrypt.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class UpdateUserPasswordOtpCommandHandler : IRequestHandler<UpdateUserPasswordOtpRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;

        public UpdateUserPasswordOtpCommandHandler(IUnitOfWork unitOfWork,IHttpContextAccessor accessor)
        {
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }
        public async Task<BaseCommonResponse> Handle(UpdateUserPasswordOtpRequest request, CancellationToken cancellationToken)
        {
            var context = _accessor?.HttpContext;

            BaseCommonResponse response = new BaseCommonResponse();
            if(request.newPassword.Length < 8)
            {
                response.Status = false;
                response.Response = "Password Cannot be less then 9 charachter in lenght";
                return response;
            }

            Guid userId = GetUserIdWithClaims(context);
            User? userFromDb = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);
            if(userFromDb == null)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "invalid Token";
                return response;
            }

            userFromDb.Password = BCrypt.Net.BCrypt.HashPassword(userFromDb.Password);
            await _unitOfWork.UserRepository.UpdateAsync(userFromDb);

            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "Password Updated Successfully";
            return response;
        }
        private Guid GetUserIdWithClaims(HttpContext? context)
        {

            if (context == null)
                throw new InvalidOperationException("This operation requires an active HTTP context.");

            var claimsId = context.User.FindFirst("Id") ?? new("Id", Guid.Empty.ToString());

            return new(claimsId.Value);
        }
    }
}
