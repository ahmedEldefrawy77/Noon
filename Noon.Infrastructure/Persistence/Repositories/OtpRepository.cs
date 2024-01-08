using Microsoft.EntityFrameworkCore;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Domain.Entities;
using Noon.Domain.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Persistence.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public OtpRepository(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task DeleteOtp(OTP otp)
        {
            await Task.Run(()=> _context.Remove(otp));
            await _context.SaveChangesAsync();
        }

        public async Task<OTP> GenerateOTPAsync(string Email)
        {
            Random random = new Random();
            Guid userId = await _userRepository.GetUserIdWithEmail(Email);

            OTP otp = new OTP();
            otp.OneTimePassword = random.Next(100000, 999999); 
            otp.DateCreatedAt = DateTime.UtcNow;
            otp.DateExAt = DateTime.UtcNow.AddMinutes(5);
            otp.UserId = userId;
            
           await Task.Run(()=> _context.OTPs.Add(otp));
           await _context.SaveChangesAsync();

            return otp;
        }

        public async Task<List<OTP>> GetAllOtpWithUserId(Guid id)
        {
            List<OTP> otpsForUser = await _context.OTPs.Where(e=>e.UserId == id).ToListAsync();
            return otpsForUser;
        }

        public bool IsWithIn5Minutes(DateTime date1, DateTime date2)
        {
            TimeSpan difference = date1 - date2;


            return Math.Abs(difference.TotalMinutes) <= 5;
        }
        public bool IsMoreThen1Day(DateTime date1, DateTime date2)
        {
            TimeSpan diff = date1 - date2;
            return Math.Abs(diff.TotalDays) >= 1;
        }
    }
}
