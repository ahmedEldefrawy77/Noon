using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities
{
    public class OTP
    {
        public Guid id { get; set; }
        public int OneTimePassword { get; set; }
        public DateTime DateCreatedAt { get; set; }
        public DateTime DateExAt { get; set; }
        public User? User { get; set; }
        public Guid UserId { get; set; }
    }
}
