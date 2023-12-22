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
    public class UpdateUserDto 
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Email { get; set; } 
        public string? PhoneNumber { get; set; }
     
    }
}
