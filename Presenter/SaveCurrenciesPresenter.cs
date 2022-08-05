using DTOs.Currency;
using Services;
using UseCases.Datos_Meli.Services;

namespace Presenters
{
    public class SaveCurrenciesPresenter : ISaveCurrenciesOutputPort, IPresenter<List<CurrencieDto>>
    {
        public List<CurrencieDto> Content { get; private set; }

        public ValueTask Handle(List<CurrencieDto> dto)
        {
            Content = dto;
            return ValueTask.CompletedTask;
        }
    }
}
