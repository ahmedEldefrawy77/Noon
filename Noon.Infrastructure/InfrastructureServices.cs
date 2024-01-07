using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Noon.Application.Contracts.Identity;
using Noon.Application.Contracts.Persistence.IBaseRepository;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.Contracts.Persistence.UnitOfWork;
using Noon.Application.DTOs.UserDtos;
using Noon.Application.DTOs.UserDtos.validator;
using Noon.Application.DTOs.Validator;
using Noon.Domain.IServices.IPicService;
using Noon.Domain.Persistence.IBaseRepository;
using Noon.Domain.Persistence.IRepository;
using Noon.Infrastructure.IdentityProvider;
using Noon.Infrastructure.Middleware;
using Noon.Infrastructure.Persistence.Repositories;
using Noon.Infrastructure.Persistence.UOW;
using Noon.Infrastructure.Services.AuthServices;
using Noon.Infrastructure.Services.PicService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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

         
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IBaseUserSettingRepository<>), typeof(BaseUserSettingRepository<>));
          
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IAuthServices, AuthService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IImageService, ImageService>();
     

            services.AddSingleton<RefreshTokenValidator>();

            services.AddTransient<IValidator<RegisterUserDto>, RegiseterUserDtoValidator>();
            services.AddTransient<IValidator<IUserDto>, IUserValidator>();

            services.AddSingleton<IJwtProvider, JwtProvider>();
            

            services.AddTransient<GlobalErrorHandlerMiddleware>();
            services.AddTransient<TransactionMiddleware>();


            return services;
        }
    }
}
