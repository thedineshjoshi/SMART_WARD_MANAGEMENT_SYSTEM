using Application;
using Application.Features.Users.Commands.CreateUser;
using Domain;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SMART_WARD_MANAGEMENT_SYSTEM
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSmartWardManagementSystemDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI(configuration);
            services.AddDomainDI();
            services.AddInfrastructureDI(configuration);
            return services;
        }
    }
}
