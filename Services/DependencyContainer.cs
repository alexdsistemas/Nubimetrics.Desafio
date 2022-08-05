
using Microsoft.Extensions.DependencyInjection;
using Services.Events;

namespace Services
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddEnterpriseBusinessServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));

            return services;

        }
    }
}