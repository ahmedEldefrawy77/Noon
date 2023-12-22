using Noon.Application.DTOs.Common;
using Noon.Application.DTOs.RefreshTokenDataTransferO;
using Noon.Application.DTOs.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.UserDtos
{
    public class RegisterUserDto : BaseDto , IUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public RefreshTokenDto? RefreshToken { get; set; }
        public DateTime DateCreatedAt { get; set; }

    }
}
