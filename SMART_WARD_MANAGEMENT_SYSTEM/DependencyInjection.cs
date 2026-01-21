using Application;
using Domain;
using Infrastructure;

namespace SMART_WARD_MANAGEMENT_SYSTEM
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSmartWardManagementSystemDI(this IServiceCollection services)
        {
            services.AddApplicationDI();
            services.AddDomainDI();
            services.AddInfrastructureDI();
            return services;
        }
    }
}
