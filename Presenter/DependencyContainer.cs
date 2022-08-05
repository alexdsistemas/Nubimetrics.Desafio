
using Microsoft.Extensions.DependencyInjection;
using UseCases.Busqueda.Sercices;
using UseCases.Datos_Meli.Services;
using UseCases.Paises.Services;
using UseCases.Usuarios.Services;

namespace Presenters
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserOutputPort, CreateUserPresenter>();
            services.AddScoped<IGetAllUsersOutputPort, GetAllUserPresenter>();
            services.AddScoped<IUpdateUserOutputPort, UpdateUserPresenter>();
            services.AddScoped<IDeleteUserOutputPort, DeleteUserPresenter>();
            services.AddScoped<IGetCountriesOutputPort, GetCountriesPresenter>();
            services.AddScoped<IGetProductsOutputPort, GetProductsPresenter>();
            services.AddSingleton<ISaveCurrenciesOutputPort, SaveCurrenciesPresenter>();
            services.AddSingleton<ISaveCurrencyOutputPort, SaveCurrencyConversionPresenter>();

            return services;

        }
    }
}