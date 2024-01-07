using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Noon.Application.Features.BackBlazeFeatures;
using Noon.Application.Features.JwtFeatures.OptionsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.CloudServices
{
    public class BackBlazeOptionsSetup : OptionSetup<BackBlazeOptions>
    {
        public BackBlazeOptionsSetup(IConfiguration configuration, string sectionName  = "BackBlaze") : base(configuration, sectionName) { }
       
    }
}
