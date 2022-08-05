using Microsoft.Extensions.DependencyInjection;
using UseCases;

namespace Meli.RemoteRepository
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddMeliRemoteRepository(this IServiceCollection services)
        {
            services.AddSingleton<IMeliRemoteRepository, MeliRepository>();
            return services;
        }
    }
}