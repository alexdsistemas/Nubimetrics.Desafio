using DTOs.Busqueda;
using DTOs.Currency;
using DTOs.Paises;
using ExceptionHandler;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using UseCases;

namespace Meli.RemoteRepository
{
    public class MeliRepository: IMeliRemoteRepository
    {
        private HttpClient Cliente { get; set; }
        public IConfiguration Configuracion { get; }

        public MeliRepository(HttpClient cliente, IConfiguration configuracion)
        {
            Cliente = cliente;
            Configuracion = configuracion;
        }

        public async Task<CountryDto> GetCountries(string country)
        {
            UriBuilder BuilderUrl = new UriBuilder
            {
                Scheme = "https",
                Host = Configuracion["ASPNETCORE_ROUTE_MELI"],
                Path = $"classified_locations/countries/{country}"
            };

            using var Response = await Cliente.GetAsync(BuilderUrl.Uri);

            if (Response.IsSuccessStatusCode)
            {
                using var contentStream =
                    await Response.Content.ReadAsStreamAsync();

                var Country = await JsonSerializer.DeserializeAsync<CountryDto>(contentStream);
                if (Country != null)
                {
                    return Country;
                }
            }

            throw new BadRequestException("No se pudo conectar con el servidor remoto.");
        }

        public async Task<SearchDto> GetProducts(string search)
        {
            UriBuilder BuilderUrl = new UriBuilder
            {
                Scheme = "https",
                Host = Configuracion["ASPNETCORE_ROUTE_MELI"],
                Path = $"sites/MLA/search",
                Query = $"q={search}"
            };

            using var Response = await Cliente.GetAsync(BuilderUrl.Uri);

            if (Response.IsSuccessStatusCode)
            {
                using var contentStream =
                    await Response.Content.ReadAsStreamAsync();

                var Product = await JsonSerializer.DeserializeAsync<SearchDto>(contentStream);
                if (Product != null)
                {
                    return Product;
                }
            }

            throw new BadRequestException("No se pudo conectar con el servidor remoto.");
        }

        public async Task<List<CurrencieDto>> GetCurrencies()
        {
            UriBuilder BuilderUrl = new UriBuilder
            {
                Scheme = "https",
                Host = Configuracion["ASPNETCORE_ROUTE_MELI"],
                Path = "currencies",
            };

            using var Response = await Cliente.GetAsync(BuilderUrl.Uri);

            if (Response.IsSuccessStatusCode)
            {
                using var contentStream =
                    await Response.Content.ReadAsStreamAsync();

                var Currencie = await JsonSerializer.DeserializeAsync<List<CurrencieDto>>(contentStream);
                if (Currencie != null)
                {
                    return Currencie;
                }
            }

            throw new BadRequestException("No se pudo conectar con el servidor remoto.");
        }

        public async Task<CurrencyConversionDto> ConversionToUSD(string idCurrencie)
        {
            UriBuilder BuilderUrl = new UriBuilder
            {
                Scheme = "https",
                Host = Configuracion["ASPNETCORE_ROUTE_MELI"],
                Path = "currency_conversions/search",
                Query = $"from={idCurrencie}&to=USD"
            };

            using var Response = await Cliente.GetAsync(BuilderUrl.Uri);

            if (Response.IsSuccessStatusCode)
            {
                using var contentStream =
                    await Response.Content.ReadAsStreamAsync();

                var currencyConversion = await JsonSerializer.DeserializeAsync<CurrencyConversionDto>(contentStream);
                if (currencyConversion != null)
                {
                    return currencyConversion;
                }
            }

            throw new BadRequestException("No se pudo conectar con el servidor remoto.");
        }
    }
}