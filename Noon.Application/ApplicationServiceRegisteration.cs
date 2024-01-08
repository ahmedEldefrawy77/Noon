using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Noon.Application.Features.JwtFeatures.OptionsSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddOptions();
            services.ConfigureOptions<AccessOptionSetup>();
            services.ConfigureOptions<BearerOptionSetup>();
            services.ConfigureOptions<RefreshOptionSetup>();
            services.ConfigureOptions<TemporarilyAccessOptionsSetup>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
