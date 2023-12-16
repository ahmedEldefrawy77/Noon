using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.JwtFeatures.Options
{
    public record RefreshOptions
    {
        public string? SecretKey { get; set; }
        public int ExpireTimeInMonths { get; set; }
    }
}
