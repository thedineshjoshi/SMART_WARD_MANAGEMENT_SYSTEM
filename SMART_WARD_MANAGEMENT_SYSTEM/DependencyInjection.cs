using Application;
using Application.Features.Users.Commands.CreateUser;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SMART_WARD_MANAGEMENT_SYSTEM
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSmartWardManagementSystemDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI(configuration);
            services.AddDomainDI();
            services.AddInfrastructureDI(configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Jwt:Issuer",
                        ValidAudience = "Jwt:Audience",
                        IssuerSigningKey = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes("Jwt:Key"))
                    };
                }
            );
            return services;
        }
    }
}
