using ExceptionHandler;
using UseCases.Busqueda.Sercices;

namespace UseCases.Busqueda
{
    public class GetProducts : IGetProductsInputPort
    {
        readonly IMeliRemoteRepository Repository;
        readonly IGetProductsOutputPort OutputPort;

        public GetProducts(IMeliRemoteRepository repository, IGetProductsOutputPort outputPort)
        {
            Repository = repository;
            OutputPort = outputPort;
        }

        public async ValueTask Handle(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                throw new BadRequestException("Debes cargar un valor para la busqueda.");
            }
            var Search = await Repository.GetProducts(search);

            await OutputPort.Handle(Search);
        }
    }
}
