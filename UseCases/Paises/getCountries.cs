using UseCases.Paises.Services;

namespace UseCases.Paises
{
    public class getCountries : IGetCountriesInputPort
    {
        readonly IMeliRemoteRepository Repository;
        readonly IGetCountriesOutputPort OutputPort;

        public getCountries(IMeliRemoteRepository repository, IGetCountriesOutputPort outputPort)
        {
            Repository = repository;
            OutputPort = outputPort;
        }

        public async ValueTask Handle(string country)
        {
            var Country = await Repository.GetCountries(country.ToUpper());

            await OutputPort.Handle(Country);
        }
    }
}
