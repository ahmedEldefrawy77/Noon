using MediatR;
using Microsoft.Extensions.Options;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.DTOs.Record;
using Noon.Application.Features.UserFeatures.Requests.Queries;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using Noon.Domain.Entities.Options;
using Noon.Infrastructure.IdentityProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Handlers.Queries
{
    public class CheckUserOtpQueryHandler : IRequestHandler<CheckUserOtpRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;
        

        public CheckUserOtpQueryHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
           
        }
        public async Task<BaseCommonResponse> Handle(CheckUserOtpRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            User? userFromDb = await _unitOfWork.UserRepository.GetUserWithEmail(request.email);
            
            List<OTP> otpsForUser = await _unitOfWork.OtpRepository.GetAllOtpWithUserId(userFromDb!.Id);
            foreach(OTP otp in otpsForUser)
            {
                if(_unitOfWork.OtpRepository.IsMoreThen1Day(DateTime.UtcNow, otp.DateExAt))
                {
                    await _unitOfWork.OtpRepository.DeleteOtp(otp);
                }

                if(request.otp == otp.OneTimePassword)
                { 
                    if (_unitOfWork.OtpRepository.IsWithIn5Minutes(DateTime.UtcNow, otp.DateExAt))
                    {  
                        
                        response.Status = true;
                        response.ResponseNumber = 200;
                        response.Response =  _jwtProvider.GetTemporarilyAccessToken(userFromDb);
                        return response;
                    }
                    else
                    {
                        response.Status = false;
                        response.ResponseNumber = 500;
                        response.Response = "this OTP is out Dated, please request another one";
                        return response;
                    }
                    
                }
            }
            response.Status = false;
            response.ResponseNumber = 500;
            response.Response = "Wrong OTP please try again";
            return response;
            
        }
    }
}
