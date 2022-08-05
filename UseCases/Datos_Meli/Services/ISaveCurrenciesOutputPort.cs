using DTOs.Currency;
using Services;

namespace UseCases.Datos_Meli.Services
{
    public interface ISaveCurrenciesOutputPort: IPort<List<CurrencieDto>>
    {
    }
}
