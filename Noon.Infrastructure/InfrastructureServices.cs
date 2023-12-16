using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noon.Application.Contracts.Identity;
using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Domain.Persistence.IRepository;
using Noon.Infrastructure.AuthServices;
using Noon.Infrastructure.IdentityProvider;
using Noon.Infrastructure.Persistence.Repositories;
using Noon.Infrastructure.Persistence.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option=> 
                                                        option.UseSqlServer(
                                                               configuration.GetConnectionString("DefaultConnection")!, b => b.MigrationsAssembly("Noon.Infrastructure")));

         
            services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IAuthServices, AuthService>();
            services.AddSingleton<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
