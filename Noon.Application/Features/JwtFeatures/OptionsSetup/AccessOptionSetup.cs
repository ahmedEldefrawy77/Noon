using Microsoft.Extensions.Configuration;
using Noon.Domain.Entities.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.JwtFeatures.OptionsSetup
{
    public class AccessOptionSetup : OptionSetup<AccessOptions>
    {
        public AccessOptionSetup(IConfiguration configure, string SectionName = "JwtAccess")
            : base(configure, SectionName)
        {

        }
    }
}
