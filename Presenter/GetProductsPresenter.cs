using DTOs.Busqueda;
using Services;
using UseCases.Busqueda.Sercices;
using ViewModels;

namespace Presenters
{
    public class GetProductsPresenter : IGetProductsOutputPort, IPresenter<GetProductsViewModel>
    {
        public GetProductsViewModel Content { get; private set; }

        public ValueTask Handle(SearchDto dto)
        {
            Content = new GetProductsViewModel(dto);
            return ValueTask.CompletedTask;
        }
    }
}
