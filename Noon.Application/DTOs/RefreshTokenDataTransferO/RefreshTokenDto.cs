using Noon.Application.DTOs.Common;
using Noon.Application.DTOs.UserDtos;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.RefreshTokenDataTransferO
{
    public class RefreshTokenDto : BaseDto
    {
        public string? Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiredAt { get; set; }

        public Guid UserId { get; set; }

        public UserDto? User { get; set; }
    }
}
