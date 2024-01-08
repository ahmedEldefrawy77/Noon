using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Persistence.IRepository
{
    public interface IOtpRepository 
    {
        Task<OTP> GenerateOTPAsync(string Email);
        Task<List<OTP>> GetAllOtpWithUserId(Guid id);
        Task DeleteOtp(OTP otp);
        bool IsWithIn5Minutes(DateTime date1, DateTime date2);
        bool IsMoreThen1Day(DateTime date1, DateTime date2);
        
    }
}
