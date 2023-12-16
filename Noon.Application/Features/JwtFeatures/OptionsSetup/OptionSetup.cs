using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.Features.JwtFeatures.OptionsSetup
{
    public class OptionSetup<T> : IConfigureOptions<T> where T : class
    {
        public string SectionName { get; set; }
        private readonly IConfiguration _configuration;
        public OptionSetup(IConfiguration configuration, string sectionName)
        {
            SectionName = sectionName;
            _configuration = configuration;
        }

        public void Configure(T options)
          => _configuration.GetSection(SectionName).Bind(options);
    }
}
