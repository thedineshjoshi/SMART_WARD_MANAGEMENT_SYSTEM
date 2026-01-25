using Application.Common.Interfaces;
using Application.Interfaces;
using Infrastructure.Logging;
using Infrastructure.Persistence;
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
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbString"));
            });
            services.AddScoped<IApplicationDbContext>(provider=>provider.GetService<ApplicationDbContext>());
            return services;
        }

    }
}
