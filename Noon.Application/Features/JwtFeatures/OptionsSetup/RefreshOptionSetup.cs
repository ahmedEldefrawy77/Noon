using Microsoft.Extensions.Configuration;
using Noon.Application.Features.JwtFeatures.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.JwtFeatures.OptionsSetup
{
    public class RefreshOptionSetup : OptionSetup<RefreshOptions>
    {
        public RefreshOptionSetup(IConfiguration configuration, string SectionName = "JwtRefresh")
            : base(configuration, SectionName) { }
    }
}
