using DTOs.Currency;

namespace UseCases.Datos_Meli.Services
{
    public interface IFileRepository
    {
        Task SaveJsonFile(List<CurrencieDto> currencies);
        Task SaveRatioInCsvFile(List<RatioDto> ratios);
    }
}
