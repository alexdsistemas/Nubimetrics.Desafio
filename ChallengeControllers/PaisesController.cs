using DTOs.Paises;
using Microsoft.AspNetCore.Mvc;
using Services;
using UseCases.Paises.Services;
using ViewModels;

namespace Controllers
{
    [ApiController]
    [Route("api/paises")]
    public class PaisesController : ControllerBase
    {
        readonly IGetCountriesInputPort GetCountriesInputPort;
        readonly IGetCountriesOutputPort GetCountriesOutputPort;

        public PaisesController(IGetCountriesInputPort getCountriesInputPort, IGetCountriesOutputPort getCountriesOutputPort)
        {
            GetCountriesInputPort = getCountriesInputPort;
            GetCountriesOutputPort = getCountriesOutputPort;
        }

        //Esta tarea entendí que solamente se podría acepar los países BR, AR, CO
        /// <summary>
        /// Buscar paises (BR,AR,CO)
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("{country:regex((^BR$)|(^AR$)|(^CO$))}")]
        public async Task<ActionResult<CountryDto>> GetCountries(string country)
        {
            if (country.ToUpper().Contains("BR") || country.ToUpper().Contains("CO"))
            {
                return Unauthorized();
            }

            await GetCountriesInputPort.Handle(country);
            return ((IPresenter<GetCountriesViewModel>)GetCountriesOutputPort).Content.Country;
        }

    }
}
