using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Noon.Application.Responses;
using Noon.Domain.Entities.Options;
using System.Text;
using System.Text.Json;


namespace Noon.Application.Features.JwtFeatures.OptionsSetup
{
    public class BearerOptionSetup : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly AccessOptions _jwtOptions;

        public BearerOptionSetup(IOptions<AccessOptions> jwtOptions) =>
            _jwtOptions = jwtOptions.Value;

        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            if (_jwtOptions.SecretKey == null)
                throw new ArgumentNullException(nameof(_jwtOptions.SecretKey));

            options.TokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = ctx =>
                {
                    ctx.Token = ctx.HttpContext.Request.Cookies["AccessToken"];

                    return Task.CompletedTask;
                },
                OnChallenge = ctx =>
                {
                    ctx.Response.OnStarting(async () =>
                    {
                        ResponseResult result = new ResponseResult("You are not authorized: Bearer");
                        string response = JsonSerializer.Serialize(result);

                        ctx.Response.ContentType = "application/json";
                        await ctx.Response.WriteAsync(response);
                    });
                    return Task.CompletedTask;
                }
            };
        }
    }
}
