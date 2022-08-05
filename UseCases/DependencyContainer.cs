

using Microsoft.Extensions.DependencyInjection;
using UseCases.Busqueda;
using UseCases.Busqueda.Sercices;
using UseCases.Datos_Meli;
using UseCases.Datos_Meli.Services;
using UseCases.Paises;
using UseCases.Paises.Services;
using UseCases.Usuarios;
using UseCases.Usuarios.Services;

namespace UseCases
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddUseCasesServices(this IServiceCollection servicios)
        {
    
            servicios.AddScoped<ICreateUserInputPort, CreateUser>();
            servicios.AddScoped<IUpdateUserInputPort, UpdateUser>();
            servicios.AddScoped<IDeleteUserInputPort, DeleteUser>();
            servicios.AddScoped<IGetAllUsersInputPort, GetAllUsers>();
            servicios.AddScoped<IGetCountriesInputPort, getCountries>();
            servicios.AddScoped<IGetProductsInputPort, GetProducts>();
            servicios.AddSingleton<ISaveCurrenciesInputPort, SaveCurrenciesInJsonFile>();
            servicios.AddSingleton<ISaveCurrencyInputPort, SaveCurrencyConversionsInCsvFile>();
            


            return servicios;
        }
    }
}