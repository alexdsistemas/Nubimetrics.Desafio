using DTOs.Busqueda;
using Microsoft.AspNetCore.Mvc;
using Services;
using UseCases.Busqueda.Sercices;
using ViewModels;

namespace Controllers
{
    [ApiController]
    [Route("api/busqueda")]
    public class SearchController : ControllerBase
    {
        readonly IGetProductsInputPort GetProductsInputPort;
        readonly IGetProductsOutputPort GetProductsOutputPort;

        public SearchController(IGetProductsInputPort getProductsInputPort, IGetProductsOutputPort getProductsOutputPort)
        {
            GetProductsInputPort = getProductsInputPort;
            GetProductsOutputPort = getProductsOutputPort;
        }



        /// <summary>
        /// Busca un producto por un Termino
        /// </summary>
        /// <param name="termino"></param>
        /// <returns></returns>
        [HttpGet("{termino}")]
        public async Task<ActionResult<SearchDto>> GetCountries(string termino)
        {
            await GetProductsInputPort.Handle(termino);
            return ((IPresenter<GetProductsViewModel>)GetProductsOutputPort).Content.Search;
        }
    }
}
