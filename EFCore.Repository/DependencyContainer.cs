using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using UseCases.Usuarios.Services;

namespace EFCore.Repository
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddLocalRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChallengeDataContext>(options =>
              options.UseSqlServer(configuration["ASPNETCORE_CONECCTIONSTRING"]));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}