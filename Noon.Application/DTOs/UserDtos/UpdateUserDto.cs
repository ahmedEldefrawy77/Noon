using Noon.Application.DTOs.Common;
using Noon.Application.DTOs.RefreshTokenDataTransferO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.UserDtos
{
    public class UpdateUserDto : BaseDto
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public RefreshTokenDto? RefreshToken { get; set; }
    }
}
