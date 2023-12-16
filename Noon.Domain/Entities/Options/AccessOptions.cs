using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Options
{
    public record AccessOptions
    {
        public string? Issuser { get; set; }
        public string? Audience { get; set; }
        public string? SecretKey { get; set; }
        public int ExpireTimeInMintes { get; set; }
    }
}
