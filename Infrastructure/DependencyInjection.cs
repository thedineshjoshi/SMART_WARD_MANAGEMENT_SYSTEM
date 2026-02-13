using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Authentication.Jwt;
using Infrastructure.Logging;
using Infrastructure.Persistence;
using Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuditLogger, SqlAuditLogger>();
            services.AddScoped<IActivityLogger, FileActivityLogger>();
            services.AddScoped<ISystemLogger, SerilogSystemLogger>();
            services.AddScoped<IFileStorageService, LocalFileStorageService>();
            services.AddScoped<Application.Common.Interfaces.IJwtTokenService, JwtTokenService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbString"));
            });
            services.AddScoped<IApplicationDbContext>(provider=>provider.GetService<ApplicationDbContext>());
            return services;
        }

    }
}
