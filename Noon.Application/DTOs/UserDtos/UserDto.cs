using Noon.Domain.Entities.Products;
using Noon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noon.Application.DTOs.Common;

namespace Noon.Application.DTOs.UserDtos
{
    public class UserDto : BaseUserDto
    {
        
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public DateTime DateCreatedAt { get; set; }
        public DateTime DateUpdatedAt { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Address>? Address { get; set; }
        public ICollection<Return>? Returns { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
