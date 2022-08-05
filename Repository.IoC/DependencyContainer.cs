using EFCore.Repository;
using FileRepository;
using Meli.RemoteRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters;
using Services;
using UseCases;

namespace Challenge.IoC
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddChallengeServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalRepository(configuration).AddMeliRemoteRepository().AddUseCasesServices().AddEnterpriseBusinessServices().AddPresenters().AddFileRepository();

            return services;
        }
    }
}