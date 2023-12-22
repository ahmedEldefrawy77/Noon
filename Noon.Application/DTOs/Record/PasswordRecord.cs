using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.Record
{
    public class PasswordRecord
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
