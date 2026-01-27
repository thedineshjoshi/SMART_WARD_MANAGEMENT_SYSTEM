using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
            return services;
        }

    }
}
