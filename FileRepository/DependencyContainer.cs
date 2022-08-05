


using Microsoft.Extensions.DependencyInjection;
using UseCases.Datos_Meli.Services;

namespace FileRepository
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddFileRepository(this IServiceCollection services)
        {
            services.AddSingleton<IFileRepository, FileRepository>();
            return services;
        }
    }
}