using MediatR;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.Features.UserFeatures.Requests.Commands;
using Noon.Application.Responses;
using Noon.Domain.Entities;
using Noon.Domain.IServices.IEmailSenderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.UserFeatures.Handlers.Commands
{
    public class GenerateUserOtpCommandHandler : IRequestHandler<GenerateUserOtpRequest, BaseCommonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public GenerateUserOtpCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }
        public async Task<BaseCommonResponse> Handle(GenerateUserOtpRequest request, CancellationToken cancellationToken)
        {
            BaseCommonResponse response = new BaseCommonResponse();
            if(request.Email == string.Empty)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "You have to provide and Email please";
                return response;
            }

            User? userFromDb = await _unitOfWork.UserRepository.GetUserWithEmail(request.Email);
            if(userFromDb == null)
            {
                response.Status = false;
                response.ResponseNumber = 500;
                response.Response = "there is no User With This Email, please provide a valid User-Email";
                return response;
            }

            OTP otp = await _unitOfWork.OtpRepository.GenerateOTPAsync(request.Email);
           
            string mailSubject = $" Noon: {otp.OneTimePassword} is the OTP for your noon Account verification";
            string mailBody =
                $"<h3>Hi {userFromDb.LastName}, {userFromDb.FirstName}<h3>\n\n"+
                $" Your One Time Password (OTP) is: {otp.OneTimePassword}\n\n"+
                " Please Note this is a temporary password and will expire in 5 Minutes. if there is been a mistake, please contact out Customer service at 11111\n\n"+
                "With Best Regards.\n Noon Team";

            await _emailService.SendEmailAsync(request.Email, mailSubject, mailBody);

            response.Status = true;
            response.ResponseNumber = 200;
            response.Response = "OTP has been sent successfully to your Mail, please Check your Mail Box";
            return response;
        }
    }
}
