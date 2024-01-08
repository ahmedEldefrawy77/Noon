using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Noon.Domain.Entities.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.JwtFeatures.OptionsSetup
{
    public class TemporarilyAccessOptionsSetup : OptionSetup<TemporarilyAccessOptions>
    {
        public TemporarilyAccessOptionsSetup(IConfiguration confiuration, string SectionName = "TemporarilyAccess")
            :base(confiuration, SectionName) { }
    }
}
