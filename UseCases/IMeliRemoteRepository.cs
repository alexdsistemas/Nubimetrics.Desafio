using DTOs.Busqueda;
using DTOs.Currency;
using DTOs.Paises;

namespace UseCases
{
    public interface IMeliRemoteRepository
    {
        Task<CountryDto> GetCountries(string country);
        Task<SearchDto> GetProducts(string search);
        Task<List<CurrencieDto>> GetCurrencies();
        Task<CurrencyConversionDto> ConversionToUSD(string idCurrencie); 
    }
}
