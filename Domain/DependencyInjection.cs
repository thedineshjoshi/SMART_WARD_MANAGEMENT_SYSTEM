using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
