using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Domain.Entities.Tokens
{
    public class Token
    {
        public string? AccessToken { get; set; }
        public DateTime AccessTokenExDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExDate { get; set; }
        public string? role { get; set; }
    }
}
