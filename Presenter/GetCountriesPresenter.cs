using DTOs.Paises;
using Services;
using UseCases.Paises.Services;
using ViewModels;

namespace Presenters
{
    public class GetCountriesPresenter : IGetCountriesOutputPort, IPresenter<GetCountriesViewModel>
    {
        public GetCountriesViewModel Content { get; private set; }

        public ValueTask Handle(CountryDto dto)
        {
            Content = new GetCountriesViewModel(dto);
            return ValueTask.CompletedTask;
        }
    }
}
