using DTOs.Paises;

namespace ViewModels
{
    public class GetCountriesViewModel
    {
        public CountryDto Country { get; private set; }

        public GetCountriesViewModel(CountryDto country)
        {
            Country = country;
        }
    }


}
