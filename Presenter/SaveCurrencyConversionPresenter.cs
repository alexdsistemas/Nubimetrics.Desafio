using Services;
using UseCases.Datos_Meli.Services;

namespace Presenters
{
    public class SaveCurrencyConversionPresenter : ISaveCurrencyOutputPort, IPresenter<bool>
    {
        public bool Content { get; private set; }

        public ValueTask Handle(bool dto)
        {
            Content = dto;
            return ValueTask.CompletedTask;
        }
    }
}
